package generator

import (
	"fmt"
	"sort"
	"strings"
	"time"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/helpers"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/generator-go-sdk/internal/featureflags"
)

// TODO: add unit tests covering this

var _ templaterForResource = modelsTemplater{}

type modelsTemplater struct {
	name  string
	model models.SDKModel
}

func (c modelsTemplater) template(data GeneratorData) (*string, error) {
	copyrightLines, err := copyrightLinesForSource(data.source)
	if err != nil {
		return nil, fmt.Errorf("retrieving copyright lines: %+v", err)
	}

	structCode, err := c.structCode(data)
	if err != nil {
		return nil, fmt.Errorf("generating struct code: %+v", err)
	}

	methods, err := c.methods(data)
	if err != nil {
		return nil, fmt.Errorf("generating functions: %+v", err)
	}

	commonTypesInclude := ""
	if data.commonTypesIncludePath != nil {
		commonTypesInclude = fmt.Sprintf(`"github.com/hashicorp/go-azure-sdk/%s/%s"`, data.sourceType, *data.commonTypesIncludePath)
	}

	template := fmt.Sprintf(`package %[1]s

import (
	"encoding/json"
	"fmt"
	"strings"
	"time"

	"github.com/hashicorp/go-azure-helpers/lang/dates"
	"github.com/hashicorp/go-azure-helpers/resourcemanager/edgezones"
	"github.com/hashicorp/go-azure-helpers/resourcemanager/identity"
	"github.com/hashicorp/go-azure-helpers/resourcemanager/systemdata"
	"github.com/hashicorp/go-azure-helpers/resourcemanager/zones"
	"github.com/hashicorp/go-azure-sdk/sdk/nullable"
	%[2]s
)

%[5]s
%[3]s
%[4]s
`, data.packageName, commonTypesInclude, *structCode, *methods, *copyrightLines)
	return &template, nil
}

func (c modelsTemplater) structCode(data GeneratorData) (*string, error) {
	// if this is an Abstract/Type Hint, we output an Interface with a manual unmarshal func that gets called wherever it's used
	if c.model.FieldNameContainingDiscriminatedValue != nil && c.model.ParentTypeName == nil {
		out := fmt.Sprintf(`
type %[1]s interface {
}

// Raw%[1]sImpl is returned when the Discriminated Value
// doesn't match any of the defined types
// NOTE: this should only be used when a type isn't defined for this type of Object (as a workaround)
// and is used only for Deserialization (e.g. this cannot be used as a Request Payload).
type Raw%[1]sImpl struct {
	Type string
	Values map[string]interface{}
}
`, c.name)
		return &out, nil
	}

	fields := make([]string, 0)
	for fieldName := range c.model.Fields {
		fields = append(fields, fieldName)
	}
	sort.Strings(fields)

	structLines := make([]string, 0)
	for _, fieldName := range fields {
		fieldDetails := c.model.Fields[fieldName]
		fieldTypeName := "FIXME"
		fieldTypeVal, err := helpers.GolangTypeForSDKObjectDefinition(fieldDetails.ObjectDefinition, nil, data.commonTypesPackageName)
		if err != nil {
			return nil, fmt.Errorf("determining type information for %q: %+v", fieldName, err)
		}
		fieldTypeName = *fieldTypeVal

		structLine, err := c.structLineForField(fieldName, fieldTypeName, fieldDetails, data)
		if err != nil {
			return nil, err
		}

		if c.model.FieldNameContainingDiscriminatedValue != nil && *c.model.FieldNameContainingDiscriminatedValue == fieldName {
			// this isn't user configurable (and is hard-coded) so there's no point outputting this
			continue
		}

		structLines = append(structLines, *structLine)
	}

	// then add any inherited fields
	parentAssignmentInfo := ""
	parentTypeName := ""
	if c.model.ParentTypeName != nil {
		if c.model.FieldNameContainingDiscriminatedValue != nil {
			_, foundParentTypeName, err := c.recurseParentModels(data, *c.model.ParentTypeName, *c.model.FieldNameContainingDiscriminatedValue)
			if err != nil {
				return nil, err
			}
			parentTypeName = *foundParentTypeName

		} else {
			parentTypeName = *c.model.ParentTypeName
		}
		parentAssignmentInfo = fmt.Sprintf("var _ %[1]s = %[2]s{}", parentTypeName, c.name)

		parent, ok := data.models[*c.model.ParentTypeName]
		if !ok {
			return nil, fmt.Errorf("couldn't find Parent Model %q for Model %q", *c.model.ParentTypeName, c.name)
		}

		parentFields := make([]string, 0)
		for fieldName := range parent.Fields {
			parentFields = append(parentFields, fieldName)
		}
		sort.Strings(parentFields)

		if len(parentFields) > 0 {
			structLines = append(structLines, fmt.Sprintf("\n// Fields inherited from %s", *c.model.ParentTypeName))
			for _, fieldName := range parentFields {
				fieldDetails := parent.Fields[fieldName]
				fieldTypeName := "FIXME"
				fieldTypeVal, err := helpers.GolangTypeForSDKObjectDefinition(fieldDetails.ObjectDefinition, nil, data.commonTypesPackageName)
				if err != nil {
					return nil, fmt.Errorf("determining type information for %q: %+v", fieldName, err)
				}
				fieldTypeName = *fieldTypeVal

				structLine, err := c.structLineForField(fieldName, fieldTypeName, fieldDetails, data)
				if err != nil {
					return nil, err
				}

				// check this field isn't used as the discriminated value
				if c.model.FieldNameContainingDiscriminatedValue != nil && *c.model.FieldNameContainingDiscriminatedValue == fieldName {
					// this isn't user configurable (and is hard-coded) so there's no point outputting this
					continue
				}

				structLines = append(structLines, *structLine)
			}
		}
	}

	formattedStructLines := make([]string, 0)
	for i, v := range structLines {
		if strings.Contains(v, "//") {
			if i > 0 && !strings.HasSuffix(formattedStructLines[i-1], "\n") {
				v = "\n" + v
			}
			if i < len(structLines)-1 {
				v += "\n"
			}
		}
		formattedStructLines = append(formattedStructLines, v)
	}

	out := fmt.Sprintf(`
%[3]s
type %[1]s struct {
%[2]s
}
`, c.name, strings.Join(formattedStructLines, "\n"), parentAssignmentInfo)
	return &out, nil
}

func (c modelsTemplater) methods(data GeneratorData) (*string, error) {
	code := make([]string, 0)

	dateFunctions, err := c.codeForDateFunctions(data)
	if err != nil {
		return nil, fmt.Errorf("generating date functions: %+v", err)
	}
	code = append(code, *dateFunctions)

	marshalFunctions, err := c.codeForMarshalFunctions(data)
	if err != nil {
		return nil, fmt.Errorf("generating marshal functions: %+v", err)
	}
	code = append(code, *marshalFunctions)

	unmarshalFunctions, err := c.codeForUnmarshalFunctions(data)
	if err != nil {
		return nil, fmt.Errorf("generating unmarshal functions: %+v", err)
	}
	code = append(code, *unmarshalFunctions)

	// TODO: validation functions (#58)

	output := strings.Join(code, "\n")
	return &output, nil
}

func (c modelsTemplater) structLineForField(fieldName, fieldType string, fieldDetails models.SDKField, data GeneratorData) (*string, error) {
	jsonDetails := fieldDetails.JsonName

	isOptional := false
	if fieldDetails.Optional {
		isOptional = true

		// TODO: this'll want rolling out by Service Package (likely using the new base layer toggle, for now)
		// but I'm disabling this entirely for the moment to workaround the issue.
		if !featureflags.OptionalDiscriminatorsShouldBeOutputWithoutOmitEmpty {
			// however if the immediate (not top-level) object definition is a Reference to a Parent it's Optional
			// by default since Parent types are output as an interface (which is implied nullable)
			if fieldDetails.ObjectDefinition.Type == models.ReferenceSDKObjectDefinitionType {
				model, ok := data.models[*fieldDetails.ObjectDefinition.ReferenceName]
				if ok && model.FieldNameContainingDiscriminatedValue != nil && model.ParentTypeName == nil {
					isOptional = false
				}
			}
		}
	}
	// TODO: proper support for ReadOnly fields, which is likely to necessitate a custom marshal func
	if isOptional || fieldDetails.ReadOnly {
		if !strings.HasPrefix(fieldType, "nullable.") {
			fieldType = fmt.Sprintf("*%s", fieldType)
		}
		jsonDetails += ",omitempty"
	} else if fieldDetails.ObjectDefinition.Nullable && !strings.HasPrefix(fieldType, "nullable.") {
		fieldType = fmt.Sprintf("*%s", fieldType)
	}

	line := fmt.Sprintf("\t%s %s `json:\"%s\"`", fieldName, fieldType, jsonDetails)

	if data.generateDescriptionsForModels && fieldDetails.Description != "" {
		description := fmt.Sprintf("// %s", fieldDetails.Description)
		line = fmt.Sprintf("%s\n%s", description, line)
	}

	return &line, nil
}

func (c modelsTemplater) dateFormatString(input models.SDKDateFormat) string {
	switch input {
	case models.RFC3339SDKDateFormat:
		return time.RFC3339

	case models.RFC3339NanoSDKDateFormat:
		return time.RFC3339Nano

	default:
		panic(fmt.Errorf("unsupported date format %q", string(input)))
	}
}

func (c modelsTemplater) codeForDateFunctions(data GeneratorData) (*string, error) {
	fieldsRequiringDateFunctions := make([]string, 0)
	// parent models are output as interfaces with no fields - so we can skip these
	// since the inherited models output the fields from their parents, the methods are output there
	if c.model.FieldNameContainingDiscriminatedValue == nil {
		for fieldName, fieldDetails := range c.model.Fields {
			if fieldDetails.DateFormat != nil {
				fieldsRequiringDateFunctions = append(fieldsRequiringDateFunctions, fieldName)
			}
		}
	}

	sort.Strings(fieldsRequiringDateFunctions)
	lines := make([]string, 0)
	for _, fieldName := range fieldsRequiringDateFunctions {
		fieldDetails := c.model.Fields[fieldName]

		dateFunction, err := c.dateFunctionForField(fieldName, fieldDetails)
		if err != nil {
			return nil, fmt.Errorf("generating Date functions for %q: %+v", fieldName, err)
		}
		lines = append(lines, *dateFunction)
	}

	// then do the parent fields, if any
	if c.model.ParentTypeName != nil {
		fieldsRequiringDateFunctions = make([]string, 0)
		parent, ok := data.models[*c.model.ParentTypeName]
		if !ok {
			return nil, fmt.Errorf("retrieving Parent Model %q for Model %q", *c.model.ParentTypeName, c.name)
		}
		for fieldName, fieldDetails := range parent.Fields {
			if fieldDetails.DateFormat != nil {
				fieldsRequiringDateFunctions = append(fieldsRequiringDateFunctions, fieldName)
			}
		}

		sort.Strings(fieldsRequiringDateFunctions)
		for _, fieldName := range fieldsRequiringDateFunctions {
			fieldDetails := parent.Fields[fieldName]

			dateFunction, err := c.dateFunctionForField(fieldName, fieldDetails)
			if err != nil {
				return nil, fmt.Errorf("generating Date functions for Parent field %q: %+v", fieldName, err)
			}
			lines = append(lines, *dateFunction)
		}
	}

	output := strings.Join(lines, "\n")
	return &output, nil
}

func (c modelsTemplater) dateFunctionForField(fieldName string, fieldDetails models.SDKField) (*string, error) {
	if fieldDetails.DateFormat == nil {
		return nil, fmt.Errorf("Date Field %q has no DateFormat", fieldName)
	}

	dateFormat := c.dateFormatString(*fieldDetails.DateFormat)

	linesForField := []string{
		fmt.Sprintf("\tfunc (o *%[1]s) Get%[2]sAsTime() (*time.Time, error) {", c.name, fieldName),
	}

	// Get{Name}AsTime method for getting *time.Time from a string
	if fieldDetails.Optional || fieldDetails.ReadOnly { // TODO: work out how to handle ReadOnly fields
		linesForField = append(linesForField, fmt.Sprintf("\t\tif o.%s == nil {", fieldName))
		linesForField = append(linesForField, fmt.Sprintf("\t\t\treturn nil, nil"))
		linesForField = append(linesForField, fmt.Sprintf("\t\t}"))
		linesForField = append(linesForField, fmt.Sprintf("\t\treturn dates.ParseAsFormat(o.%s, %q)", fieldName, dateFormat))
	} else {
		linesForField = append(linesForField, fmt.Sprintf("\t\treturn dates.ParseAsFormat(&o.%s, %q)", fieldName, dateFormat))
	}

	linesForField = append(linesForField, fmt.Sprintf("\t}\n"))

	// if the Field is ReadOnly then there's no point outputting a Setable function.
	if !fieldDetails.ReadOnly {
		// Set{Name}AsTime method - for setting time.Time -> string
		linesForField = append(linesForField, fmt.Sprintf("\tfunc (o *%[1]s) Set%[2]sAsTime(input time.Time) {", c.name, fieldName))
		linesForField = append(linesForField, fmt.Sprintf("\t\tformatted := input.Format(%q)", dateFormat))
		if fieldDetails.Optional {
			linesForField = append(linesForField, fmt.Sprintf("\t\to.%s = &formatted", fieldName))
		} else {
			linesForField = append(linesForField, fmt.Sprintf("\t\to.%s = formatted", fieldName))
		}
		linesForField = append(linesForField, fmt.Sprintf("\t}\n"))
	}

	out := strings.Join(linesForField, "\n")
	return &out, nil
}

func (c modelsTemplater) codeForMarshalFunctions(data GeneratorData) (*string, error) {
	output := ""

	if c.model.DiscriminatedValue != nil {
		if c.model.FieldNameContainingDiscriminatedValue == nil {
			return nil, fmt.Errorf("model %q must contain a TypeHintIn when a TypeHintValue is present", c.name)
		}
		if c.model.ParentTypeName == nil {
			return nil, fmt.Errorf("model %q must contain a ParentTypeName when a TypeHintValue is present", c.name)
		}

		parentModel, ok := data.models[*c.model.ParentTypeName]
		if !ok {
			return nil, fmt.Errorf("the parent model %q for model %q was not found", *c.model.ParentTypeName, c.name)
		}

		// the TypeHintIn field comes from the parent and so won't be output on the inherited items
		field, ok := parentModel.Fields[*c.model.FieldNameContainingDiscriminatedValue]
		if !ok {
			if parentModel.ParentTypeName != nil {
				parentField, _, err := c.recurseParentModels(data, *c.model.ParentTypeName, *c.model.FieldNameContainingDiscriminatedValue)
				if err != nil {
					return nil, err
				}
				field = *parentField
			} else {
				return nil, fmt.Errorf("the field %q was not found on the parent model %q for model %q", *c.model.FieldNameContainingDiscriminatedValue, *c.model.ParentTypeName, c.name)
			}
		}

		output = fmt.Sprintf(`
var _ json.Marshaler = %[1]s{}

func (s %[1]s) MarshalJSON() ([]byte, error) {
	type wrapper %[1]s
	wrapped := wrapper(s)
	encoded, err := json.Marshal(wrapped)
	if err != nil {
		return nil, fmt.Errorf("marshaling %[1]s: %%+v", err)
	}

	var decoded map[string]interface{}
	if err := json.Unmarshal(encoded, &decoded); err != nil {
		return nil, fmt.Errorf("unmarshaling %[1]s: %%+v", err)
	}
	decoded[%[2]q] = %[3]q

	encoded, err = json.Marshal(decoded)
	if err != nil {
		return nil, fmt.Errorf("re-marshaling %[1]s: %%+v", err)
	}

	return encoded, nil
}
`, c.name, field.JsonName, *c.model.DiscriminatedValue)
	}

	return &output, nil
}

func (c modelsTemplater) codeForUnmarshalFunctions(data GeneratorData) (*string, error) {
	unmarshalFunction, err := c.codeForUnmarshalStructFunction(data)
	if err != nil {
		return nil, fmt.Errorf("generating code for unmarshal struct function: %+v", err)
	}

	parentFunction, err := c.codeForUnmarshalParentFunction(data)
	if err != nil {
		return nil, fmt.Errorf("generating code for unmarshal parent function: %+v", err)
	}

	output := fmt.Sprintf(`
%s
%s
`, *unmarshalFunction, *parentFunction)
	return &output, nil
}

func (c modelsTemplater) codeForUnmarshalParentFunction(data GeneratorData) (*string, error) {
	// if this is a Discriminated Type (e.g. Parent) then we need to generate an Unmarshal{Name}Implementation
	// function which can be used in any usages
	lines := make([]string, 0)
	if c.model.IsDiscriminatedParentType() {
		modelsImplementingThisClass := make([]string, 0)
		for modelName, model := range data.models {
			if model.ParentTypeName == nil || model.FieldNameContainingDiscriminatedValue == nil || model.DiscriminatedValue == nil || modelName == c.name {
				continue
			}

			// sanity-checking
			if *model.ParentTypeName != c.name {
				continue
			}

			if *model.FieldNameContainingDiscriminatedValue != *c.model.FieldNameContainingDiscriminatedValue {
				return nil, fmt.Errorf("implementation %q uses a different discriminated field (%q) than parent %q (%q)", modelName, *model.FieldNameContainingDiscriminatedValue, c.name, *c.model.FieldNameContainingDiscriminatedValue)
			}

			modelsImplementingThisClass = append(modelsImplementingThisClass, modelName)
		}

		// sanity-checking
		if len(modelsImplementingThisClass) == 0 && featureflags.SkipDiscriminatedParentTypes() == false {
			return nil, fmt.Errorf("model %q is a discriminated parent type with no implementations", c.name)
		}
		jsonFieldName := c.model.Fields[*c.model.FieldNameContainingDiscriminatedValue].JsonName
		// NOTE: unmarshaling null returns an empty map, which'll mean the `ok` fails
		// the 'type' field being omitted will also mean that `ok` is false
		lines = append(lines, fmt.Sprintf(`
func Unmarshal%[1]sImplementation(input []byte) (%[1]s, error) {
	if input == nil {
		return nil, nil
	}

	var temp map[string]interface{}
	if err := json.Unmarshal(input, &temp); err != nil {
		return nil, fmt.Errorf("unmarshaling %[1]s into map[string]interface: %%+v", err)
	}

	value, ok := temp[%[2]q].(string)
	if !ok {
		return nil, nil
	}
`, c.name, jsonFieldName))

		sort.Strings(modelsImplementingThisClass)
		for _, implementationName := range modelsImplementingThisClass {
			model := data.models[implementationName]

			lines = append(lines, fmt.Sprintf(`
	if strings.EqualFold(value, %[1]q) {
		var out %[2]s
		if err := json.Unmarshal(input, &out); err != nil {
			return nil, fmt.Errorf("unmarshaling into %[2]s: %%+v", err)
		}
		return out, nil
	}
`, *model.DiscriminatedValue, implementationName))
		}

		// if it doesn't match - we generate and deserialize into a 'Raw{Name}Impl' type - named intentionally
		// so that we don't conflict with a generated 'Raw{Name}' type which exists in a handful of Swaggers
		lines = append(lines, fmt.Sprintf(`
	out := Raw%[1]sImpl{
		Type:   value,
		Values: temp,
	}
	return out, nil
`, c.name))

		lines = append(lines, "}")
	}

	output := strings.Join(lines, "\n")
	return &output, nil
}

func (c modelsTemplater) codeForUnmarshalStructFunction(data GeneratorData) (*string, error) {
	// this is a parent, therefore there'll be no struct fields to check here
	if c.model.IsDiscriminatedParentType() {
		out := ""
		return &out, nil
	}

	lines := make([]string, 0)

	// fields either require unmarshaling or can be explicitly assigned, determine which
	fieldsRequiringAssignment := make([]string, 0)
	fieldsRequiringUnmarshalling := make([]string, 0)
	for fieldName, fieldDetails := range c.model.Fields {
		topLevelObject := helpers.InnerMostSDKObjectDefinition(fieldDetails.ObjectDefinition)
		if topLevelObject.Type == models.ReferenceSDKObjectDefinitionType {
			model, ok := data.models[*topLevelObject.ReferenceName]
			if ok && model.IsDiscriminatedParentType() {
				fieldsRequiringUnmarshalling = append(fieldsRequiringUnmarshalling, fieldName)
				continue
			}
		}

		fieldsRequiringAssignment = append(fieldsRequiringAssignment, fieldName)
	}
	if c.model.ParentTypeName != nil {
		parent, ok := data.models[*c.model.ParentTypeName]
		if !ok {
			return nil, fmt.Errorf("Parent Model %q (for Model %q) was not found", *c.model.ParentTypeName, c.name)
		}
		for fieldName, fieldDetails := range parent.Fields {
			// also double-check if the parent has any fields matching the same conditions
			topLevelObject := helpers.InnerMostSDKObjectDefinition(fieldDetails.ObjectDefinition)
			if topLevelObject.Type == models.ReferenceSDKObjectDefinitionType {
				model, ok := data.models[*topLevelObject.ReferenceName]
				if ok && model.IsDiscriminatedParentType() {
					fieldsRequiringUnmarshalling = append(fieldsRequiringUnmarshalling, fieldName)
					continue
				}
			}

			// however specifically for the parent we don't want to assign the `type` field since we don't output it
			// so check the implementation model to determine which field the `type` is in, and assign if they
			// don't match
			//
			// at this point since we know there's a parent-implementation relationship, there's no need to nil-check
			if *c.model.FieldNameContainingDiscriminatedValue != fieldName {
				fieldsRequiringAssignment = append(fieldsRequiringAssignment, fieldName)
			}
		}
	}

	// we only need a custom unmarshal function when there's something needing unmarshaling
	// else the default unmarshaler will be fine
	if len(fieldsRequiringUnmarshalling) > 0 {
		lines = append(lines, fmt.Sprintf(`
var _ json.Unmarshaler = &%[1]s{}

func (s *%[1]s) UnmarshalJSON(bytes []byte) error {`, c.name))

		// first for each regular field, decode & assign that
		if len(fieldsRequiringAssignment) > 0 {
			lines = append(lines, fmt.Sprintf(`type alias %[1]s
	var decoded alias
	if err := json.Unmarshal(bytes, &decoded); err != nil {
		return fmt.Errorf("unmarshaling into %[1]s: %%+v", err)
	}
`, c.name))

			sort.Strings(fieldsRequiringAssignment)
			for _, fieldName := range fieldsRequiringAssignment {
				lines = append(lines, fmt.Sprintf("s.%[1]s = decoded.%[1]s", fieldName))
			}
		}

		lines = append(lines, fmt.Sprintf(`
	var temp map[string]json.RawMessage
	if err := json.Unmarshal(bytes, &temp); err != nil {
		return fmt.Errorf("unmarshaling %[1]s into map[string]json.RawMessage: %%+v", err)
	}
`, c.name))

		sort.Strings(fieldsRequiringUnmarshalling)
		for _, fieldName := range fieldsRequiringUnmarshalling {
			fieldDetails, ok := c.model.Fields[fieldName]
			if !ok {
				if c.model.ParentTypeName == nil {
					return nil, fmt.Errorf("field %q was not found on Model %q which has no Parent", fieldName, c.name)
				}
				parent, ok := data.models[*c.model.ParentTypeName]
				if !ok {
					return nil, fmt.Errorf("parent model %q was not found", *c.model.ParentTypeName)
				}
				fieldDetails, ok = parent.Fields[fieldName]
				if !ok {
					return nil, fmt.Errorf("field %q was not found on Model %q or Parent %q", fieldName, c.name, *c.model.ParentTypeName)
				}
			}
			topLevelObjectDef := helpers.InnerMostSDKObjectDefinition(fieldDetails.ObjectDefinition)

			supportedDiscriminatorWrappers := map[models.SDKObjectDefinitionType]struct{}{
				models.DictionarySDKObjectDefinitionType: {},
				models.ListSDKObjectDefinitionType:       {},
				models.ReferenceSDKObjectDefinitionType:  {},
			}
			if _, supported := supportedDiscriminatorWrappers[fieldDetails.ObjectDefinition.Type]; !supported {
				return nil, fmt.Errorf("discriminators can only be unwrapped for Dictionaries, Lists and References but got %q for field %q in model %q", fieldDetails.ObjectDefinition.Type, fieldName, c.name)
			}

			if fieldDetails.ObjectDefinition.Type == models.DictionarySDKObjectDefinitionType {
				if fieldDetails.ObjectDefinition.NestedItem == nil {
					return nil, fmt.Errorf("dictionaries of discriminators require a NestedItem but didn't get one for field %q in model %q", fieldName, c.name)
				}
				if fieldDetails.ObjectDefinition.NestedItem.Type != models.ReferenceSDKObjectDefinitionType {
					return nil, fmt.Errorf("dictionaries of discriminators only support a single level deep but got a non-Reference type for field %q in model %q", fieldName, c.name)
				}

				// if the Dictionary is optional, we need to assign the pointer value
				assignmentPrefix := ""
				if fieldDetails.Optional {
					assignmentPrefix = "&"
				}

				// TODO: handle the Dictionary Element being Optional if necessary
				lines = append(lines, fmt.Sprintf(`
	if v, ok := temp[%[5]q]; ok {
		var dictionaryTemp map[string]json.RawMessage
		if err := json.Unmarshal(v, &dictionaryTemp); err != nil {
			return fmt.Errorf("unmarshaling %[1]s into dictionary map[string]json.RawMessage: %%+v", err)
		}

		output := make(map[string]%[2]s)
		for key, val := range dictionaryTemp {
			impl, err := Unmarshal%[2]sImplementation(val)
			if err != nil {
				return fmt.Errorf("unmarshaling key %%q field '%[1]s' for '%[3]s': %%+v", key, err)
			}
			output[key] = impl
		}
		s.%[1]s = %[4]soutput
	}`, fieldName, *topLevelObjectDef.ReferenceName, c.name, assignmentPrefix, fieldDetails.JsonName))
			}

			if fieldDetails.ObjectDefinition.Type == models.ListSDKObjectDefinitionType {
				if fieldDetails.ObjectDefinition.NestedItem == nil {
					return nil, fmt.Errorf("lists of discriminators require a NestedItem but didn't get one for field %q in model %q", fieldName, c.name)
				}
				if fieldDetails.ObjectDefinition.NestedItem.Type != models.ReferenceSDKObjectDefinitionType {
					return nil, fmt.Errorf("lists of discriminators only support a single level deep but got a non-Reference type for field %q in model %q", fieldName, c.name)
				}

				// if the List is optional, we need to assign the pointer value
				assignmentPrefix := ""
				if fieldDetails.Optional {
					assignmentPrefix = "&"
				}

				// TODO: handle the List Element being Optional if necessary

				lines = append(lines, fmt.Sprintf(`
	if v, ok := temp[%[5]q]; ok {
		var listTemp []json.RawMessage
		if err := json.Unmarshal(v, &listTemp); err != nil {
			return fmt.Errorf("unmarshaling %[1]s into list []json.RawMessage: %%+v", err)
		}

		output := make([]%[2]s, 0)
		for i, val := range listTemp {
			impl, err := Unmarshal%[2]sImplementation(val)
			if err != nil {
				return fmt.Errorf("unmarshaling index %%d field '%[1]s' for '%[3]s': %%+v", i, err)
			}
			output = append(output, impl)
		}
		s.%[1]s = %[4]soutput
	}`, fieldName, *topLevelObjectDef.ReferenceName, c.name, assignmentPrefix, fieldDetails.JsonName))
			}

			if fieldDetails.ObjectDefinition.Type == models.ReferenceSDKObjectDefinitionType {
				lines = append(lines, fmt.Sprintf(`
	if v, ok := temp[%[4]q]; ok {
		impl, err := Unmarshal%[2]sImplementation(v)
		if err != nil {
			return fmt.Errorf("unmarshaling field '%[1]s' for '%[3]s': %%+v", err)
		}
		s.%[1]s = impl
	}`, fieldName, *topLevelObjectDef.ReferenceName, c.name, fieldDetails.JsonName))
			}
		}

		lines = append(lines, "return nil")
		lines = append(lines, "}")
	}

	output := strings.Join(lines, "\n")
	return &output, nil
}

// recurseParentModels walks the models hierarchy to find the parentName and field details of the model for disciminated types
// This is a temporary measure until we update the swagger importer to connect the model fields inheritance for multiple parents.
// Tracked at: https://github.com/hashicorp/pandora/issues/1235
func (c modelsTemplater) recurseParentModels(data GeneratorData, model string, typeHint string) (*models.SDKField, *string, error) {
	parentModel, ok := data.models[model]
	if !ok {
		return nil, nil, fmt.Errorf("the parent model %q for model %q was not found", model, c.name)
	}
	field, ok := parentModel.Fields[typeHint]
	if !ok {
		if parentModel.ParentTypeName != nil {
			parentField, parentName, err := c.recurseParentModels(data, *parentModel.ParentTypeName, typeHint)
			if err != nil {
				return nil, nil, err
			}

			return parentField, parentName, nil
		} else {
			return nil, nil, fmt.Errorf("the field %q was not found on the parent model or any of its parents for model %q", typeHint, c.name)
		}
	}

	return &field, &model, nil
}
