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
	out := ""
	structName := c.name

	// parent models get a Base{model}Impl struct so as not to conflict with their interface name
	if c.model.IsDiscriminatedParentType() {
		structName = fmt.Sprintf("Base%sImpl", c.name)
	}

	fields := make([]string, 0)
	for fieldName := range c.model.Fields {
		fields = append(fields, fieldName)
	}
	sort.Strings(fields)

	// If this is a child model, determine its ancestry
	parentAssignmentInfo := ""
	ancestorTypeNames := make([]string, 0)
	if c.model.ParentTypeName != nil {
		ancestorTypeNames = append(ancestorTypeNames, *c.model.ParentTypeName)
		if c.model.FieldNameContainingDiscriminatedValue != nil {
			_, foundAncestorTypeNames, err := c.findModelAncestry(data, *c.model.ParentTypeName, *c.model.FieldNameContainingDiscriminatedValue)
			if err != nil {
				return nil, err
			}
			ancestorTypeNames = *foundAncestorTypeNames
		}

		// Since ancestor interfaces embed each other, we only need to satisfy the immediate parent interface
		parentAssignmentInfo = fmt.Sprintf("var _ %[1]s = %[2]s{}", ancestorTypeNames[0], structName)
	}

	// If this is a parent model, we output an Interface with a manual unmarshal func that gets called wherever it's used
	if c.model.IsDiscriminatedParentType() {
		interfaceLines := make([]string, 0, len(ancestorTypeNames)+1)

		// First we embed any ancestor types (in reverse ancestral order for neatness)
		if len(ancestorTypeNames) > 0 {
			for i := len(ancestorTypeNames) - 1; i >= 0; i-- {
				interfaceLines = append(interfaceLines, ancestorTypeNames[i])
			}
		}

		// Then we implement a method for the base type
		interfaceLines = append(interfaceLines, fmt.Sprintf(`%[1]s() %[2]s`, c.name, structName))

		// Output an interface for the parent type
		out += fmt.Sprintf(`
type %[1]s interface {
	%[2]s
}

`, c.name, strings.Join(interfaceLines, "\n"))
	}

	// Build struct field lines
	structLines, err := c.structLinesForModel(data, fields, false, false)
	if err != nil {
		return nil, fmt.Errorf("building struct lines for %q model: %+v", c.name, err)
	}

	// Format the model struct field lines
	formattedStructLines := make([]string, 0)
	for i, v := range *structLines {
		if strings.HasPrefix(strings.TrimSpace(v), "//") {
			if i > 0 && !strings.HasSuffix(formattedStructLines[i-1], "\n") {
				v = "\n" + v
			}
			if i < len(*structLines)-1 {
				v += "\n"
			}
		}
		formattedStructLines = append(formattedStructLines, v)
	}

	// When the struct name doesn't match the model name, the struct should implement the model interface
	if structName != c.name {
		parentAssignmentInfo = fmt.Sprintf("var _ %[1]s = %[2]s{}", c.name, structName)
	}

	// Determine any behavioral struct field lines, if enabled
	behavioralStructLines := ""
	if data.allowOmittingDiscriminatedValue {
		if c.model.FieldNameContainingDiscriminatedValue != nil {
			behavioralStructLines += strings.ReplaceAll(`
	// Model Behaviors
	OmitDiscriminatedValue bool ''json:"-"''
`, "''", "`")
		}
	}

	// Output the model struct
	out += fmt.Sprintf(`
%[4]s
type %[1]s struct {
%[2]s
%[3]s
}
`, structName, strings.Join(formattedStructLines, "\n"), behavioralStructLines, parentAssignmentInfo)

	// When the struct name doesn't match the model name, output a method to satisfy the model interface
	if structName != c.name {
		out += fmt.Sprintf(`

func (s %[1]s) %[2]s() %[1]s {
	return s
}
`, structName, c.name)
	}

	parentModelFunctions, err := c.codeForParentStructFunctions(data)
	if err != nil {
		return nil, fmt.Errorf("generating parent model functions: %+v", err)
	}
	out += *parentModelFunctions

	// Parent models also get an implementation struct for use as a fallback when unmarshalling and no child type is found
	if c.model.IsDiscriminatedParentType() {
		// Output a Raw{Type}Impl struct for use as a fallback when unmarshalling an unimplemented discriminated type
		implementationStructName := fmt.Sprintf("Raw%sImpl", c.name)

		out += fmt.Sprintf(`
var _ %[1]s = %[3]s{}

// %[3]s is returned when the Discriminated Value doesn't match any of the defined types
// NOTE: this should only be used when a type isn't defined for this type of Object (as a workaround)
// and is used only for Deserialization (e.g. this cannot be used as a Request Payload).
type %[3]s struct {
	%[2]s %[4]s
	Type string
	Values map[string]interface{}
}

func (s %[3]s) %[1]s() %[4]s {
	return s.%[2]s
}

`, c.name, camelCase(c.name), implementationStructName, structName)

		// Output functions for Raw{Type}Impl to satisfy ancestor interfaces
		for _, ancestorName := range ancestorTypeNames {
			// the parent model we're returning will get a Base{model}Impl struct
			ancestorStructName := fmt.Sprintf("Base%sImpl", ancestorName)

			out += fmt.Sprintf(`
func (s %[1]s) %[2]s() %[3]s {
	return s.%[4]s.%[2]s()
}

`, implementationStructName, ancestorName, ancestorStructName, camelCase(c.name))
		}
	}

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

func (c modelsTemplater) structLinesForModel(data GeneratorData, fieldNames []string, excludeComments, excludeDiscriminatedParentMembers bool) (*[]string, error) {
	// When `excludeComments = true`, no code comments will be output
	// When `excludeDiscriminatedParentMembers = true`, any fields that reference a parent model (i.e. an interface rather than a struct), will be omitted

	output := make([]string, 0)

	// Add the fields for this model
	for _, fieldName := range fieldNames {
		fieldDetails := c.model.Fields[fieldName]

		topLevelObject := helpers.InnerMostSDKObjectDefinition(fieldDetails.ObjectDefinition)
		if excludeDiscriminatedParentMembers && topLevelObject.Type == models.ReferenceSDKObjectDefinitionType {
			if referencedModel, ok := data.models[*topLevelObject.ReferenceName]; ok && referencedModel.IsDiscriminatedParentType() {
				// Skip fields that reference a parent model (i.e. an interface rather than a struct)
				continue
			}
		}

		fieldTypeName := "FIXME"
		fieldTypeVal, err := helpers.GolangTypeForSDKObjectDefinition(fieldDetails.ObjectDefinition, nil, data.commonTypesPackageName)
		if err != nil {
			return nil, fmt.Errorf("determining type information for %q: %+v", fieldName, err)
		}
		fieldTypeName = *fieldTypeVal

		structLine, err := c.structLineForField(fieldName, fieldTypeName, fieldDetails, data, excludeComments)
		if err != nil {
			return nil, err
		}

		output = append(output, *structLine)
	}

	// Then add any inherited fields
	ancestorTypeNames := make([]string, 0)
	if c.model.ParentTypeName != nil {
		ancestorTypeNames = append(ancestorTypeNames, *c.model.ParentTypeName)
		if c.model.FieldNameContainingDiscriminatedValue != nil {
			_, foundAncestorTypeNames, err := c.findModelAncestry(data, *c.model.ParentTypeName, *c.model.FieldNameContainingDiscriminatedValue)
			if err != nil {
				return nil, err
			}
			ancestorTypeNames = *foundAncestorTypeNames
		}

		// We want to include fields from all ancestors, grouped by ancestor name
		ancestorFields := make(map[string]map[string]models.SDKField)
		for _, ancestorTypeName := range ancestorTypeNames {
			parent, ok := data.models[ancestorTypeName]
			if !ok {
				return nil, fmt.Errorf("couldn't find Ancestor Model %q for Model %q", ancestorTypeName, c.name)
			}
			ancestorFields[ancestorTypeName] = make(map[string]models.SDKField)
			for fieldName, fieldDetails := range parent.Fields {
				ancestorFields[ancestorTypeName][fieldName] = fieldDetails
			}
		}

		// Get sorted slices of ancestors' field names
		ancestorFieldNames := make(map[string][]string)
		for ancestorName := range ancestorFields {
			ancestorFieldNames[ancestorName] = make([]string, 0, len(ancestorFields[ancestorName]))
			for fieldName := range ancestorFields[ancestorName] {
				ancestorFieldNames[ancestorName] = append(ancestorFieldNames[ancestorName], fieldName)
			}
			sort.Strings(ancestorFieldNames[ancestorName])
		}

		// Append fields from all ancestors to struct
		for _, ancestorName := range ancestorTypeNames {
			if len(ancestorFieldNames[ancestorName]) > 0 {
				if !excludeComments {
					output = append(output, fmt.Sprintf("\n// Fields inherited from %s", ancestorName))
				}
				for _, fieldName := range ancestorFieldNames[ancestorName] {
					fieldDetails := ancestorFields[ancestorName][fieldName]

					topLevelObject := helpers.InnerMostSDKObjectDefinition(fieldDetails.ObjectDefinition)
					if excludeDiscriminatedParentMembers && topLevelObject.Type == models.ReferenceSDKObjectDefinitionType {
						if referencedModel, ok := data.models[*topLevelObject.ReferenceName]; ok && referencedModel.IsDiscriminatedParentType() {
							// Skip fields that reference a parent model (i.e. an interface rather than a struct)
							continue
						}
					}

					fieldTypeName := "FIXME"
					fieldTypeVal, err := helpers.GolangTypeForSDKObjectDefinition(fieldDetails.ObjectDefinition, nil, data.commonTypesPackageName)
					if err != nil {
						return nil, fmt.Errorf("determining type information for %q: %+v", fieldName, err)
					}
					fieldTypeName = *fieldTypeVal

					structLine, err := c.structLineForField(fieldName, fieldTypeName, fieldDetails, data, excludeComments)
					if err != nil {
						return nil, err
					}

					output = append(output, *structLine)
				}
			}
		}
	}

	return &output, nil
}

func (c modelsTemplater) structLineForField(fieldName, fieldType string, fieldDetails models.SDKField, data GeneratorData, excludeComments bool) (*string, error) {
	jsonDetails := fieldDetails.JsonName

	if strings.HasPrefix(fieldType, "nullable.") {
		// nullable types should have the omitempty tag option and not be pointers
		jsonDetails += ",omitempty"
	} else {
		if c.fieldIsOptional(data, fieldDetails) || fieldDetails.ReadOnly {
			fieldType = fmt.Sprintf("*%s", fieldType)
			jsonDetails += ",omitempty"
		} else if fieldDetails.ObjectDefinition.Nullable {
			fieldType = fmt.Sprintf("*%s", fieldType)
		}
	}

	line := fmt.Sprintf("\t%s %s `json:\"%s\"`", fieldName, fieldType, jsonDetails)

	if data.generateDescriptionsForModels && !excludeComments && fieldDetails.Description != "" {
		comment := wrapOnWordBoundary(fieldDetails.Description, 120, "//")
		line = fmt.Sprintf("%s\n%s", comment, line)
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
	if fieldDetails.Optional || fieldDetails.ReadOnly {
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

func (c modelsTemplater) codeForParentStructFunctions(data GeneratorData) (*string, error) {
	out := ""
	structName := c.name

	if c.model.ParentTypeName == nil {
		return &out, nil
	}

	// parent models get a Base{model}Impl struct so as not to conflict with their interface name
	if c.model.IsDiscriminatedParentType() {
		structName = fmt.Sprintf("Base%sImpl", c.name)
	}

	ancestorTypeNames := make([]string, 0)

	ancestorTypeNames = append(ancestorTypeNames, *c.model.ParentTypeName)
	if c.model.FieldNameContainingDiscriminatedValue != nil {
		_, foundAncestorTypeNames, err := c.findModelAncestry(data, *c.model.ParentTypeName, *c.model.FieldNameContainingDiscriminatedValue)
		if err != nil {
			return nil, err
		}
		ancestorTypeNames = *foundAncestorTypeNames
	}

	// We want to include fields from all ancestors, grouped by ancestor name
	ancestorFields := make(map[string]map[string]models.SDKField)
	for _, ancestorTypeName := range ancestorTypeNames {
		parent, ok := data.models[ancestorTypeName]
		if !ok {
			return nil, fmt.Errorf("couldn't find Ancestor Model %q for Model %q", ancestorTypeName, c.name)
		}
		ancestorFields[ancestorTypeName] = make(map[string]models.SDKField)
		for fieldName, fieldDetails := range parent.Fields {
			ancestorFields[ancestorTypeName][fieldName] = fieldDetails
		}
	}

	// Get sorted slices of ancestors' field names
	ancestorFieldNames := make(map[string][]string)
	for ancestorName := range ancestorFields {
		ancestorFieldNames[ancestorName] = make([]string, 0, len(ancestorFields[ancestorName]))
		for fieldName := range ancestorFields[ancestorName] {
			ancestorFieldNames[ancestorName] = append(ancestorFieldNames[ancestorName], fieldName)
		}
		sort.Strings(ancestorFieldNames[ancestorName])
	}

	// Output functions to satisfy ancestor interfaces
	for i, ancestorName := range ancestorTypeNames {
		// parent models get a Base{model}Impl struct so as not to conflict with their interface name
		ancestorStructName := fmt.Sprintf("Base%sImpl", ancestorName)
		ancestorStructFields := make([]string, 0)

		// Get fields from the current/next ancestor, plus any older ancestors
		for j := i; j < len(ancestorTypeNames); j++ {
			nextAncestorName := ancestorTypeNames[j]
			for _, fieldName := range ancestorFieldNames[nextAncestorName] {
				ancestorStructFields = append(ancestorStructFields, fmt.Sprintf(`%[1]s: s.%[1]s,`, fieldName))
			}
		}

		out += fmt.Sprintf(`
func (s %[1]s) %[2]s() %[3]s {
	return %[3]s{
		%[4]s
	}
}

`, structName, ancestorName, ancestorStructName, strings.Join(ancestorStructFields, "\n"))
	}

	return &out, nil
}

func (c modelsTemplater) codeForMarshalFunctions(data GeneratorData) (*string, error) {
	output := ""

	readOnlyFields := make([]string, 0)
	nullableFields := make([]string, 0)
	for _, field := range c.model.Fields {
		if field.ReadOnly {
			readOnlyFields = append(readOnlyFields, field.JsonName)
		}
		if field.ObjectDefinition.Nullable {
			nullableFields = append(nullableFields, field.JsonName)
		}
	}
	sort.Strings(readOnlyFields)

	// Only output a Marshal function when there are discriminated value or read-only fields to customize
	if c.model.DiscriminatedValue == nil && len(readOnlyFields) == 0 && len(nullableFields) == 0 {
		return &output, nil
	}

	// add nullable support for resource manager sdk without touching the field type
	if data.sourceType == models.ResourceManagerSourceDataType && len(nullableFields) > 0 && c.model.DiscriminatedValue == nil {
		output += fmt.Sprintf(`
var _ json.Marshaler = %[1]s{}

func (s %[1]s) MarshalJSON() ([]byte, error) {
	return nullable.MarshalNullableStruct(s)
}
`, c.name)
		return &output, nil
	}

	if c.model.DiscriminatedValue != nil {
		if c.model.FieldNameContainingDiscriminatedValue == nil {
			return nil, fmt.Errorf("model %q must contain a TypeHintIn when a TypeHintValue is present", c.name)
		}
		if c.model.ParentTypeName == nil {
			return nil, fmt.Errorf("model %q must contain a ParentTypeName when a TypeHintValue is present", c.name)
		}
	}

	structName := c.name

	// parent models get a Base{model}Impl struct so as not to conflict with their interface name
	if c.model.IsDiscriminatedParentType() {
		structName = fmt.Sprintf("Base%sImpl", c.name)
	}

	output += fmt.Sprintf(`
var _ json.Marshaler = %[1]s{}

func (s %[1]s) MarshalJSON() ([]byte, error) {
	type wrapper %[1]s
	wrapped := wrapper(s)
	encoded, err := json.Marshal(wrapped)
	if err != nil {
		return nil, fmt.Errorf("marshaling %[1]s: %%+v", err)
	}

	var decoded map[string]interface{}
	if err = json.Unmarshal(encoded, &decoded); err != nil {
		return nil, fmt.Errorf("unmarshaling %[1]s: %%+v", err)
	}

`, structName)

	for _, fieldName := range readOnlyFields {
		output += fmt.Sprintf("	delete(decoded, %[1]q)\n", fieldName)
	}

	if c.model.DiscriminatedValue != nil {
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

		if data.allowOmittingDiscriminatedValue {
			output += fmt.Sprintf(`
	if !s.OmitDiscriminatedValue {
		decoded[%[1]q] = %[2]q
	}
`, field.JsonName, *c.model.DiscriminatedValue)
		} else {
			output += fmt.Sprintf("	decoded[%[1]q] = %[2]q\n", field.JsonName, *c.model.DiscriminatedValue)
		}
	}

	output += fmt.Sprintf(`

	encoded, err = json.Marshal(decoded)
	if err != nil {
		return nil, fmt.Errorf("re-marshaling %[1]s: %%+v", err)
	}

	return encoded, nil
}
`, structName)

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
	output := ""

	if !c.model.IsDiscriminatedParentType() {
		return &output, nil
	}

	// parent models get a Base{model}Impl struct so as not to conflict with their interface name
	structName := fmt.Sprintf("Base%sImpl", c.name)

	// if this is a Discriminated Type (e.g. Parent) then we need to generate an Unmarshal{Name}Implementation
	// function which can be used in any usages
	lines := make([]string, 0)
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

	// Discover discriminated field, which may be defined on an ancestor model
	var discriminatedValueField models.SDKField
	var ok bool
	if discriminatedValueField, ok = c.model.Fields[*c.model.FieldNameContainingDiscriminatedValue]; !ok && c.model.ParentTypeName != nil {
		ancestorTypeNames := []string{*c.model.ParentTypeName}
		if c.model.FieldNameContainingDiscriminatedValue != nil {
			_, foundAncestorTypeNames, err := c.findModelAncestry(data, *c.model.ParentTypeName, *c.model.FieldNameContainingDiscriminatedValue)
			if err != nil {
				return nil, err
			}
			ancestorTypeNames = *foundAncestorTypeNames

			// Look for the discriminated value field in all ancestors
			for _, ancestorTypeName := range ancestorTypeNames {
				if discriminatedValueField, ok = data.models[ancestorTypeName].Fields[*c.model.FieldNameContainingDiscriminatedValue]; ok {
					break
				}
			}
		}
	}

	// Fail forward when unmarshalling - if the `temp` map is nil or empty, or if the discriminated value field is
	// missing, we will proceed to unmarshal into the base implementation struct, rather than returning nil. When
	// assigning the discriminated value field, we'll also attempt to stringify it, in case the API returns a different
	// type than we are expecting.
	lines = append(lines, fmt.Sprintf(`
func Unmarshal%[1]sImplementation(input []byte) (%[1]s, error) {
	if input == nil {
		return nil, nil
	}

	var temp map[string]interface{}
	if err := json.Unmarshal(input, &temp); err != nil {
		return nil, fmt.Errorf("unmarshaling %[1]s into map[string]interface: %%+v", err)
	}

	var value string
	if v, ok := temp[%[2]q]; ok {
		value = fmt.Sprintf("%%v", v)
	}
`, c.name, discriminatedValueField.JsonName))

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

	// If no child type was matched, we generate and deserialize into a `Raw{Name}Impl` type - named intentionally
	// so that we don't conflict with a generated `Raw{Name}` type which exists in a handful of Swaggers. The
	// `Raw{Name}Impl` type implements the parent model interface, so the parent fields can be retrieved that way, and
	// arbitrary fields can be found in the `Values` map.
	implementationStructName := fmt.Sprintf("Raw%sImpl", c.name)
	lines = append(lines, fmt.Sprintf(`
	var parent %[1]s
	if err := json.Unmarshal(input, &parent); err != nil {
		return nil, fmt.Errorf("unmarshaling into %[1]s: %%+v", err)
	}

	return %[2]s{
		%[3]s: parent,
		Type: value,
		Values: temp,
	}, nil
`, structName, implementationStructName, camelCase(c.name)))

	lines = append(lines, "}")

	output += strings.Join(lines, "\n")
	return &output, nil
}

func (c modelsTemplater) codeForUnmarshalStructFunction(data GeneratorData) (*string, error) {
	structName := c.name

	// parent models get a Base{model}Impl struct so as not to conflict with their interface name
	if c.model.IsDiscriminatedParentType() {
		structName = fmt.Sprintf("Base%sImpl", c.name)
	}

	fieldNames := make([]string, 0)
	for fieldName := range c.model.Fields {
		fieldNames = append(fieldNames, fieldName)
	}
	sort.Strings(fieldNames)

	lines := make([]string, 0)

	// Determine which fields can be directly assigned and which must be explicitly unmarshalled
	fieldsRequiringAssignment := make([]string, 0)
	fieldsRequiringUnmarshalling := make(map[string]models.SDKField)

	for _, fieldName := range fieldNames {
		fieldDetails := c.model.Fields[fieldName]

		// Check if the model field references a model interface, which will require explicit unmarshalling
		topLevelObject := helpers.InnerMostSDKObjectDefinition(fieldDetails.ObjectDefinition)
		if topLevelObject.Type == models.ReferenceSDKObjectDefinitionType {
			model, ok := data.models[*topLevelObject.ReferenceName]
			if ok && model.IsDiscriminatedParentType() {
				fieldsRequiringUnmarshalling[fieldName] = fieldDetails
				continue
			}
		}

		fieldsRequiringAssignment = append(fieldsRequiringAssignment, fieldName)
	}

	// Enumerate fields from ancestor models, determine which fields to assign directory or explicitly unmarshal
	if c.model.ParentTypeName != nil {
		ancestorTypeNames := []string{*c.model.ParentTypeName}
		if c.model.FieldNameContainingDiscriminatedValue != nil {
			_, foundAncestorTypeNames, err := c.findModelAncestry(data, *c.model.ParentTypeName, *c.model.FieldNameContainingDiscriminatedValue)
			if err != nil {
				return nil, err
			}
			ancestorTypeNames = *foundAncestorTypeNames
		}

		ancestorFields := make(map[string]models.SDKField)

		// We want to include fields from all ancestors
		for _, ancestorTypeName := range ancestorTypeNames {
			parent, ok := data.models[ancestorTypeName]
			if !ok {
				return nil, fmt.Errorf("couldn't find Ancestor Model %q for Model %q", ancestorTypeName, c.name)
			}
			for fieldName, fieldDetails := range parent.Fields {
				if _, ok := ancestorFields[fieldName]; ok {
					// Skip fields already present from a closer ancestor
					continue
				}
				ancestorFields[fieldName] = fieldDetails
			}
		}

		ancestorFieldNames := make([]string, 0)
		for fieldName := range ancestorFields {
			ancestorFieldNames = append(ancestorFieldNames, fieldName)
		}
		sort.Strings(ancestorFieldNames)

		for _, fieldName := range ancestorFieldNames {
			fieldDetails := ancestorFields[fieldName]
			// Check if the ancestor field references a model interface, which requires explicit unmarshalling
			topLevelObject := helpers.InnerMostSDKObjectDefinition(fieldDetails.ObjectDefinition)
			if topLevelObject.Type == models.ReferenceSDKObjectDefinitionType {
				model, ok := data.models[*topLevelObject.ReferenceName]
				if ok && model.IsDiscriminatedParentType() {
					fieldsRequiringUnmarshalling[fieldName] = fieldDetails
					continue
				}
			}

			// Note: previously we skipped unmarshalling the `type` field for discriminated models, we now intentionally
			// populate this field to allow consumers the option of inspecting it. Note that we do not marshal the `type`
			// field, so it cannot be set by consumers.
			fieldsRequiringAssignment = append(fieldsRequiringAssignment, fieldName)
		}
	}

	// Determine struct fields for unmarshalling
	aliasStructLines, err := c.structLinesForModel(data, fieldNames, true, true)
	if err != nil {
		return nil, fmt.Errorf("building struct lines for %q model: %+v", c.name, err)
	}

	// Format the model struct field lines
	formattedStructLines := make([]string, 0)
	for i, v := range *aliasStructLines {
		if strings.HasPrefix(strings.TrimSpace(v), "//") {
			if i > 0 && !strings.HasSuffix(formattedStructLines[i-1], "\n") {
				v = "\n" + v
			}
			if i < len(*aliasStructLines)-1 {
				v += "\n"
			}
		}
		formattedStructLines = append(formattedStructLines, v)
	}

	aliasTypeDefinition := fmt.Sprintf(`struct {
%[1]s
}`, strings.Join(formattedStructLines, "\n"))

	// we only need a custom unmarshal function when there's something needing unmarshalling
	// else the default unmarshaler will be fine
	if len(fieldsRequiringUnmarshalling) > 0 {
		lines = append(lines, fmt.Sprintf(`var _ json.Unmarshaler = &%[1]s{}

func (s *%[1]s) UnmarshalJSON(bytes []byte) error {`, structName))

		// first for each regular field, decode & assign that
		if len(fieldsRequiringAssignment) > 0 {
			lines = append(lines, fmt.Sprintf(`	var decoded %[1]s
	if err := json.Unmarshal(bytes, &decoded); err != nil {
		return fmt.Errorf("unmarshaling: %%+v", err)
	}
`, aliasTypeDefinition))

			for _, fieldName := range fieldsRequiringAssignment {
				lines = append(lines, fmt.Sprintf("s.%[1]s = decoded.%[1]s", fieldName))
			}
		}

		lines = append(lines, fmt.Sprintf(`
	var temp map[string]json.RawMessage
	if err := json.Unmarshal(bytes, &temp); err != nil {
		return fmt.Errorf("unmarshaling %[1]s into map[string]json.RawMessage: %%+v", err)
	}
`, structName))

		fieldNamesRequiringUnmarshalling := make([]string, 0, len(fieldsRequiringUnmarshalling))
		for fieldName := range fieldsRequiringUnmarshalling {
			fieldNamesRequiringUnmarshalling = append(fieldNamesRequiringUnmarshalling, fieldName)
		}
		sort.Strings(fieldNamesRequiringUnmarshalling)
		for _, fieldName := range fieldNamesRequiringUnmarshalling {
			fieldDetails, ok := fieldsRequiringUnmarshalling[fieldName]
			if !ok {
				return nil, fmt.Errorf("internal-error: field %q for model %q was not found in `fieldsRequiringUnmarshalling` map", fieldName, c.name)
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
	}`, fieldName, *topLevelObjectDef.ReferenceName, structName, assignmentPrefix, fieldDetails.JsonName))
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
	}`, fieldName, *topLevelObjectDef.ReferenceName, structName, assignmentPrefix, fieldDetails.JsonName))
			}

			assignmentPrefix := ""
			fieldType, err := helpers.GolangTypeForSDKObjectDefinition(fieldDetails.ObjectDefinition, nil, data.commonTypesPackageName)
			if err != nil {
				return nil, err
			}

			// if the field is optional, read-only, or nullable, but not a nullable type, we need to assign the pointer value
			if (c.fieldIsOptional(data, fieldDetails) || fieldDetails.ReadOnly || fieldDetails.ObjectDefinition.Nullable) && !strings.HasPrefix(*fieldType, "nullable.") {
				assignmentPrefix = "&"
			}

			if fieldDetails.ObjectDefinition.Type == models.ReferenceSDKObjectDefinitionType {
				lines = append(lines, fmt.Sprintf(`
	if v, ok := temp[%[5]q]; ok {
		impl, err := Unmarshal%[2]sImplementation(v)
		if err != nil {
			return fmt.Errorf("unmarshaling field '%[1]s' for '%[3]s': %%+v", err)
		}
		s.%[1]s = %[4]simpl
	}`, fieldName, *topLevelObjectDef.ReferenceName, structName, assignmentPrefix, fieldDetails.JsonName))
			}
		}

		lines = append(lines, "\nreturn nil")
		lines = append(lines, "}")
	}

	output := strings.Join(lines, "\n")
	return &output, nil
}

// findModelAncestry walks the models hierarchy to find all ancestors of the specified model for discriminated types.
func (c modelsTemplater) findModelAncestry(data GeneratorData, parentModelName, typeHint string) (*models.SDKField, *[]string, error) {
	if data.recurseParentModels {
		field, model, err := c.recurseParentModels(data, parentModelName, typeHint)
		if err != nil {
			return nil, nil, err
		}
		return field, &[]string{*model}, nil
	}

	parentModel, ok := data.models[parentModelName]
	if !ok {
		return nil, nil, fmt.Errorf("the parent model %q for model %q was not found", parentModelName, c.name)
	}

	ancestors := []string{parentModelName}
	var field *models.SDKField

	if parentField, ok := parentModel.Fields[typeHint]; ok {
		field = &parentField
	}

	if parentModel.ParentTypeName != nil {
		parentField, older, err := c.findModelAncestry(data, *parentModel.ParentTypeName, typeHint)
		if err != nil {
			return nil, nil, err
		}
		if field == nil {
			field = parentField
		}
		ancestors = append(ancestors, *older...)
	}

	return field, &ancestors, nil
}

// recurseParentModels walks the models hierarchy to find the parentName and field details of the model for discriminated types
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

func (c modelsTemplater) fieldIsOptional(data GeneratorData, fieldDetails models.SDKField) (isOptional bool) {
	if fieldDetails.Optional {
		isOptional = true

		// If the immediate (not top-level) object definition is a Reference to a Parent it's Optional
		// by default since Parent types are output as an interface (which is implied nullable)
		if fieldDetails.ObjectDefinition.Type == models.ReferenceSDKObjectDefinitionType {
			model, ok := data.models[*fieldDetails.ObjectDefinition.ReferenceName]
			if ok && model.FieldNameContainingDiscriminatedValue != nil && model.ParentTypeName == nil {
				isOptional = false
			}
		}
	}

	return
}
