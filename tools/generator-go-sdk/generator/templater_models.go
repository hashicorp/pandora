package generator

import (
	"fmt"
	"sort"
	"strings"
	"time"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

// TODO: the unmarshal func needs rewriting
// this would also allow this behaviour to be feature-toggled
// _all_ Constants can now be normalized via
// w.Example = w.Example.Normalize() - meaning that we want:
/*
var _ json.Unmarshal = Foo{}

func (f *Foo) Unmarshal(..) error {
	type wrapper Foo
	var intermediate wrapper
	if err := json.Unmarshal(input, &intermediate); err != nil {
		// TODO: do whatever you have to do
	}
	f.Foo = intermediate.Foo.Normalize()
	// or
	if v := intermediate.Foo; v != nil {
		normalized := v.Normalize()
		f.Foo = &normalized
	}

	// TODO: discriminated type stuff too

	return nil
}
*/

var _ templater = modelsTemplater{}

type modelsTemplater struct {
	name  string
	model resourcemanager.ModelDetails
}

func (c modelsTemplater) template(data ServiceGeneratorData) (*string, error) {
	structCode, err := c.structCode(data)
	if err != nil {
		return nil, fmt.Errorf("generating struct code: %+v", err)
	}

	methods, err := c.methods(data)
	if err != nil {
		return nil, fmt.Errorf("generating functions: %+v", err)
	}

	template := fmt.Sprintf(`package %[1]s

import (
	"encoding/json"
	"fmt"
	"strings"
	"time"

	"github.com/hashicorp/go-azure-helpers/lang/dates"
	"github.com/hashicorp/go-azure-helpers/resourcemanager/identity"
)

%[2]s
%[3]s
`, data.packageName, *structCode, *methods)
	return &template, nil
}

func (c modelsTemplater) structCode(data ServiceGeneratorData) (*string, error) {
	// if this is an Abstract/Type Hint, we output an Interface with a manual unmarshal func that gets called wherever it's used
	if c.model.TypeHintIn != nil && c.model.ParentTypeName == nil {
		out := fmt.Sprintf(`type %[1]s interface {
}`, c.name)
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
		fieldTypeVal, err := golangTypeNameForObjectDefinition(fieldDetails.ObjectDefinition)
		if err != nil {
			return nil, fmt.Errorf("determining type information for %q: %+v", fieldName, err)
		}
		fieldTypeName = *fieldTypeVal

		structLine, err := c.structLineForField(fieldName, fieldTypeName, fieldDetails, data)
		if err != nil {
			return nil, err
		}

		if c.model.TypeHintIn != nil && *c.model.TypeHintIn == fieldName {
			// this isn't user configurable (and is hard-coded) so there's no point outputting this
			continue
		}

		structLines = append(structLines, *structLine)
	}

	// then add any inherited fields
	parentAssignmentInfo := ""
	if c.model.ParentTypeName != nil {
		parentAssignmentInfo = fmt.Sprintf("var _ %[1]s = %[2]s{}", *c.model.ParentTypeName, c.name)

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
				fieldTypeVal, err := golangTypeNameForObjectDefinition(fieldDetails.ObjectDefinition)
				if err != nil {
					return nil, fmt.Errorf("determining type information for %q: %+v", fieldName, err)
				}
				fieldTypeName = *fieldTypeVal

				structLine, err := c.structLineForField(fieldName, fieldTypeName, fieldDetails, data)
				if err != nil {
					return nil, err
				}

				// check this field isn't used as the discriminated value
				if c.model.TypeHintIn != nil && *c.model.TypeHintIn == fieldName {
					// this isn't user configurable (and is hard-coded) so there's no point outputting this
					continue
				}

				structLines = append(structLines, *structLine)
			}
		}
	}

	out := fmt.Sprintf(`
%[3]s
type %[1]s struct {
%[2]s
}
`, c.name, strings.Join(structLines, "\n"), parentAssignmentInfo)
	return &out, nil
}

func (c modelsTemplater) methods(data ServiceGeneratorData) (*string, error) {
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

func (c modelsTemplater) structLineForField(fieldName, fieldType string, fieldDetails resourcemanager.FieldDetails, data ServiceGeneratorData) (*string, error) {
	jsonDetails := fieldDetails.JsonName

	isOptional := false
	if fieldDetails.Optional {
		isOptional = true

		// however if the immediate (not top-level) object definition is a Reference to a Parent it's Optional
		// by default since Parent types are output as an interface (which is implied nullable)
		if fieldDetails.ObjectDefinition.Type == resourcemanager.ReferenceApiObjectDefinitionType {
			model := data.models[*fieldDetails.ObjectDefinition.ReferenceName]
			if model.TypeHintIn != nil && model.ParentTypeName == nil {
				isOptional = false
			}
		}
	}

	if isOptional {
		fieldType = fmt.Sprintf("*%s", fieldType)
		jsonDetails += ",omitempty"
	}

	line := fmt.Sprintf("\t%s %s `json:\"%s\"`", fieldName, fieldType, jsonDetails)
	return &line, nil
}

func (c modelsTemplater) dateFormatString(input resourcemanager.DateFormat) string {
	switch input {
	case resourcemanager.RFC3339:
		return time.RFC3339

	case resourcemanager.RFC3339Nano:
		return time.RFC3339Nano

	default:
		panic(fmt.Errorf("unsupported date format %q", string(input)))
	}
}

func (c modelsTemplater) codeForDateFunctions(data ServiceGeneratorData) (*string, error) {
	fieldsRequiringDateFunctions := make([]string, 0)
	for fieldName, fieldDetails := range c.model.Fields {
		if fieldDetails.DateFormat != nil {
			fieldsRequiringDateFunctions = append(fieldsRequiringDateFunctions, fieldName)
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

func (c modelsTemplater) dateFunctionForField(fieldName string, fieldDetails resourcemanager.FieldDetails) (*string, error) {
	if fieldDetails.DateFormat == nil {
		return nil, fmt.Errorf("Date Field %q has no DateFormat", fieldName)
	}

	dateFormat := c.dateFormatString(*fieldDetails.DateFormat)

	linesForField := []string{
		fmt.Sprintf("\tfunc (o *%[1]s) Get%[2]sAsTime() (*time.Time, error) {", c.name, fieldName),
	}

	// Get{Name}AsTime method for getting *time.Time from a string
	if fieldDetails.Optional {
		linesForField = append(linesForField, fmt.Sprintf("\t\tif o.%s == nil {", fieldName))
		linesForField = append(linesForField, fmt.Sprintf("\t\t\treturn nil, nil"))
		linesForField = append(linesForField, fmt.Sprintf("\t\t}"))
		linesForField = append(linesForField, fmt.Sprintf("\t\treturn dates.ParseAsFormat(o.%s, %q)", fieldName, dateFormat))
	} else {
		linesForField = append(linesForField, fmt.Sprintf("\t\treturn dates.ParseAsFormat(&o.%s, %q)", fieldName, dateFormat))
	}

	linesForField = append(linesForField, fmt.Sprintf("\t}\n"))

	// Set{Name}AsTime method - for setting time.Time -> string
	linesForField = append(linesForField, fmt.Sprintf("\tfunc (o *%[1]s) Set%[2]sAsTime(input time.Time) {", c.name, fieldName))
	linesForField = append(linesForField, fmt.Sprintf("\t\tformatted := input.Format(%q)", dateFormat))
	if fieldDetails.Optional {
		linesForField = append(linesForField, fmt.Sprintf("\t\to.%s = &formatted", fieldName))
	} else {
		linesForField = append(linesForField, fmt.Sprintf("\t\to.%s = formatted", fieldName))
	}
	linesForField = append(linesForField, fmt.Sprintf("\t}\n"))

	out := strings.Join(linesForField, "\n")
	return &out, nil
}

func (c modelsTemplater) codeForMarshalFunctions(data ServiceGeneratorData) (*string, error) {
	output := ""

	if c.model.TypeHintValue != nil {
		if c.model.TypeHintIn == nil {
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
		field, ok := parentModel.Fields[*c.model.TypeHintIn]
		if !ok {
			return nil, fmt.Errorf("the field %q was not found on the parent model %q for model %q", *c.model.TypeHintIn, *c.model.ParentTypeName, c.name)
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
`, c.name, field.JsonName, *c.model.TypeHintValue)
	}

	return &output, nil
}

func (c modelsTemplater) codeForUnmarshalFunctions(data ServiceGeneratorData) (*string, error) {
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

func (c modelsTemplater) codeForUnmarshalParentFunction(data ServiceGeneratorData) (*string, error) {
	// if this is a Discriminated Type (e.g. Parent) then we need to generate a unmarshal{Name}Implementations
	// function which can be used in any usages
	lines := make([]string, 0)
	if c.model.TypeHintIn != nil && c.model.ParentTypeName == nil {
		modelsImplementingThisClass := make([]string, 0)
		for modelName, model := range data.models {
			if model.ParentTypeName == nil || model.TypeHintIn == nil || model.TypeHintValue == nil || modelName == c.name {
				continue
			}

			// sanity-checking
			if *model.ParentTypeName != c.name {
				continue
			}

			if *model.TypeHintIn != *c.model.TypeHintIn {
				return nil, fmt.Errorf("implementation %q uses a different discriminated field (%q) than parent %q (%q)", modelName, *model.TypeHintIn, c.name, *c.model.TypeHintIn)
			}

			modelsImplementingThisClass = append(modelsImplementingThisClass, modelName)
		}

		// sanity-checking
		if len(modelsImplementingThisClass) == 0 {
			return nil, fmt.Errorf("model %q is a discriminated parent type with no implementations", c.name)
		}
		jsonFieldName := c.model.Fields[*c.model.TypeHintIn].JsonName
		// NOTE: unmarshaling null returns an empty map, which'll mean the `ok` fails
		// the 'type' field being omitted will also mean that `ok` is false
		lines = append(lines, fmt.Sprintf(`
func unmarshal%[1]sImplementation(input []byte) (%[1]s, error) {
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
`, *model.TypeHintValue, implementationName))
		}

		// if it doesn't match - we generate and deserialize into a 'Raw{Name}Impl' type - named intentionally
		// so that we don't conflict with a generated 'Raw{Name}' type which exists in a handful of Swaggers
		jsonIgnoreTag := "`json:\"-\"`"
		lines = append(lines, fmt.Sprintf(`
	type Raw%[1]sImpl struct {
		Type string %[2]s
		Values map[string]interface{} %[2]s
	}
	out := Raw%[1]sImpl{
		Type:   value,
		Values: temp,
	}
	return out, nil
`, c.name, jsonIgnoreTag, *c.model.TypeHintIn))

		lines = append(lines, "}")
	}

	output := strings.Join(lines, "\n")
	return &output, nil
}

func (c modelsTemplater) codeForUnmarshalStructFunction(data ServiceGeneratorData) (*string, error) {
	// this is a parent, therefore there'll be no struct fields to check here
	if c.model.TypeHintIn != nil && c.model.TypeHintValue == nil && c.model.ParentTypeName == nil {
		out := ""
		return &out, nil
	}

	// determine if there's any constants which require normalization
	fieldsContainingConstants := make([]string, 0)
	// then determine if there's any discriminated types present which require custom unmarshaling
	fieldsContainingDiscriminatedTypes := make([]string, 0)
	fieldsToUnmarshalManually := make([]string, 0)
	for fieldName, fieldDetails := range c.model.Fields {
		definition := topLevelObjectDefinition(fieldDetails.ObjectDefinition)
		if definition.Type == resourcemanager.ReferenceApiObjectDefinitionType {
			if _, ok := data.constants[*definition.ReferenceName]; ok {
				fieldsContainingConstants = append(fieldsContainingConstants, fieldName)
				continue
			}

			model, ok := data.models[*definition.ReferenceName]
			if !ok {
				return nil, fmt.Errorf("data error: %q was a reference to neither a known constant or model", *definition.ReferenceName)
			}

			if model.TypeHintIn != nil && model.ParentTypeName == nil {
				fieldsContainingDiscriminatedTypes = append(fieldsContainingDiscriminatedTypes, fieldName)
				continue
			}
		}

		fieldsToUnmarshalManually = append(fieldsToUnmarshalManually, fieldName)
	}
	sort.Strings(fieldsContainingConstants)
	sort.Strings(fieldsContainingDiscriminatedTypes)
	sort.Strings(fieldsToUnmarshalManually)

	// if there's nothing to unmarshal manually, we can skip outputting this function
	if len(fieldsToUnmarshalManually) == len(c.model.Fields) {
		out := ""
		return &out, nil
	}

	lines := make([]string, 0)

	// constants need to be normalized
	if len(fieldsContainingConstants) > 0 {
		lines = append(lines, "// normalize any constants on the way through")
		for _, fieldName := range fieldsContainingConstants {
			fieldDetails := c.model.Fields[fieldName]
			// NOTE: at this point in time we only support either top-level or one-level deep constants
			// that is `Constant`, `List<Constant>` and `Dictionary<Constant>` - as multi-level deep
			// shouldn't be required.
			if fieldDetails.ObjectDefinition.Type == resourcemanager.DictionaryApiObjectDefinitionType {
				if fieldDetails.ObjectDefinition.NestedItem == nil {
					return nil, fmt.Errorf("constant for field %q is a List with no nested item", fieldName)
				}
				if fieldDetails.ObjectDefinition.NestedItem.Type != resourcemanager.ReferenceApiObjectDefinitionType {
					return nil, fmt.Errorf("constant for field %q is a List of a non-reference - got %q", fieldName, fieldDetails.ObjectDefinition.String())
				}
				if fieldDetails.ObjectDefinition.NestedItem.ReferenceName == nil {
					return nil, fmt.Errorf("constant for field %q is a List without a reference - got %q", fieldName, fieldDetails.ObjectDefinition.String())
				}
				// create a dictionary and map/normalize that
				if fieldDetails.Optional {
					lines = append(lines, fmt.Sprintf(`
if val := decoded.%[1]s; val != nil {
	items := make(map[string]%[2]s, 0)
	for k, v := range val {
		items[k] = v.Normalize()
	}
	s.%[1]s = &items
}
`, fieldName, *fieldDetails.ObjectDefinition.NestedItem.ReferenceName))
					continue
				}

				lines = append(lines, fmt.Sprintf(`
if val := decoded.%[1]s; val != nil {
	items := make(map[string]%[2]s, 0)
	for k, v := range val {
		items[k] = v.Normalize()
	}
	s.%[1]s = items
}
`, fieldName, *fieldDetails.ObjectDefinition.NestedItem.ReferenceName))
				continue
			}

			if fieldDetails.ObjectDefinition.Type == resourcemanager.ListApiObjectDefinitionType {
				if fieldDetails.ObjectDefinition.NestedItem == nil {
					return nil, fmt.Errorf("constant for field %q is a List with no nested item", fieldName)
				}
				if fieldDetails.ObjectDefinition.NestedItem.Type != resourcemanager.ReferenceApiObjectDefinitionType {
					return nil, fmt.Errorf("constant for field %q is a List of a non-reference - got %q", fieldName, fieldDetails.ObjectDefinition.String())
				}
				if fieldDetails.ObjectDefinition.NestedItem.ReferenceName == nil {
					return nil, fmt.Errorf("constant for field %q is a List without a reference - got %q", fieldName, fieldDetails.ObjectDefinition.String())
				}
				// create a slice and map/normalize that
				if fieldDetails.Optional {
					lines = append(lines, fmt.Sprintf(`
if val := decoded.%[1]s; val != nil {
	items := make([]%[2]s, 0)
	for _, v := range val {
		items = append(items, v.Normalize())
	}
	s.%[1]s = &items
}
`, fieldName, *fieldDetails.ObjectDefinition.NestedItem.ReferenceName))
					continue
				}

				lines = append(lines, fmt.Sprintf(`
if val := decoded.%[1]s; val != nil {
	items := make([]%[2]s, 0)
	for _, v := range val {
		items = append(items, v.Normalize())
	}
	s.%[1]s = items
}
`, fieldName, *fieldDetails.ObjectDefinition.NestedItem.ReferenceName))
				continue
			}

			if fieldDetails.ObjectDefinition.Type == resourcemanager.ReferenceApiObjectDefinitionType {
				// map it directly
				if fieldDetails.Optional {
					lines = append(lines, fmt.Sprintf(`
if v := decoded.%[1]s; v != nil {
	normalized := v.Normalize()
	s.%[1]s = &normalized 
}
`, fieldName))
					continue
				}

				lines = append(lines, fmt.Sprintf(`s.%[1]s = decoded.%[1]s.Normalize()`, fieldName))
				continue
			}

			return nil, fmt.Errorf("cannot normalize parent type: %+v", fieldDetails.ObjectDefinition.String())
		}
	}

	// manually parse out any custom discriminators
	if len(fieldsContainingDiscriminatedTypes) > 0 {
		lines = append(lines, "")
		lines = append(lines, fmt.Sprintf(`
	// manually parse out any discriminated types
	var decoded map[string]interface{}
	if err := json.Unmarshal(encoded, &decoded); err != nil {
		return nil, fmt.Errorf("unmarshaling %[1]s: %%+v", err)
	}
`, c.name))
		for _, fieldName := range fieldsContainingDiscriminatedTypes {
			fieldDetails := c.model.Fields[fieldName]
			// NOTE: at this point in time we only support either top-level or one-level deep discriminated typed
			// that is `Type`, `List<Type>` and `Dictionary<Type>` - as multi-level deep
			// shouldn't be required.

			if fieldDetails.ObjectDefinition.Type == resourcemanager.DictionaryApiObjectDefinitionType {
				if fieldDetails.ObjectDefinition.NestedItem == nil {
					return nil, fmt.Errorf("dictionary nested item was nil: %s", fieldDetails.ObjectDefinition)
				}
				if fieldDetails.ObjectDefinition.NestedItem.Type != resourcemanager.ReferenceApiObjectDefinitionType {
					return nil, fmt.Errorf("dictionary nested item reference type was not a reference: %s", fieldDetails.ObjectDefinition)
				}
				if fieldDetails.ObjectDefinition.NestedItem.ReferenceName == nil {
					return nil, fmt.Errorf("dictionary nested item reference was nil: %s", fieldDetails.ObjectDefinition)
				}
				referenceType := *fieldDetails.ObjectDefinition.NestedItem.ReferenceName
				if fieldDetails.Optional {
					lines = append(lines, fmt.Sprintf(`
if v := decoded[%[2]q]; v != nil {
	items := make(map[string]%[3]s, 0)
	var dict map[string]json.RawMessage
	if err := json.Unmarshal(v, &dict); err != nil {
		return nil, fmt.Errorf("unmarshaling json value for %[2]q into map[string]%[3]s: %%+v", err)
	}
	for k, item := range dict {
		inner, err := unmarshal%[3]sImplementation(item)
		if err != nil {
			return nil, fmt.Errorf("unmarshaling implementation for %[3]s item %%q: %%+v", k, err) 
		}
		if inner != nil {
			items[k] = *inner
		}
	}
	s.%[1]s = items
}
`, fieldName, fieldDetails.JsonName, referenceType))
					continue
				}

				lines = append(lines, fmt.Sprintf(`
if v := decoded[%[2]q]; v != nil {
	items := make(map[string]%[3]s, 0)
	var dict map[string]json.RawMessage
	if err := json.Unmarshal(v, &dict); err != nil {
		return nil, fmt.Errorf("unmarshaling json value for %[2]q into map[string]%[3]s: %%+v", err)
	}
	for k, item := range dict {
		inner, err := unmarshal%[3]sImplementation(item)
		if err != nil {
			return nil, fmt.Errorf("unmarshaling implementation for %[3]s item %%q: %%+v", k, err) 
		}
		items[k] = *inner
	}
	s.%[1]s = items
}
`, fieldName, fieldDetails.JsonName, referenceType))
				continue
			}

			if fieldDetails.ObjectDefinition.Type == resourcemanager.ListApiObjectDefinitionType {
				if fieldDetails.ObjectDefinition.NestedItem == nil {
					return nil, fmt.Errorf("list nested item was nil: %s", fieldDetails.ObjectDefinition)
				}
				if fieldDetails.ObjectDefinition.NestedItem.Type != resourcemanager.ReferenceApiObjectDefinitionType {
					return nil, fmt.Errorf("list nested item reference type was not a reference: %s", fieldDetails.ObjectDefinition)
				}
				if fieldDetails.ObjectDefinition.NestedItem.ReferenceName == nil {
					return nil, fmt.Errorf("list nested item reference was nil: %s", fieldDetails.ObjectDefinition)
				}
				referenceType := *fieldDetails.ObjectDefinition.NestedItem.ReferenceName
				if fieldDetails.Optional {
					lines = append(lines, fmt.Sprintf(`
if v := decoded[%[2]q]; v != nil {
	items := make([]%[3]s, 0)
	var list []json.RawMessage
	if err := json.Unmarshal(v, &list); err != nil {
		return nil, fmt.Errorf("unmarshaling json value for %[2]q into []%[3]s: %%+v", err)
	}
	for i, item := range list {
		inner, err := unmarshal%[3]sImplementation(item)
		if err != nil {
			return nil, fmt.Errorf("unmarshaling implementation for %[3]s item %%d: %%+v", i, err) 
		}
		if inner != nil {
			items = append(items, *inner)
		}
	}
	s.%[1]s = items
}
`, fieldName, fieldDetails.JsonName, referenceType))
					continue
				}

				lines = append(lines, fmt.Sprintf(`
if v := decoded[%[2]q]; v != nil {
	items := make([]%[3]s, 0)
	var list []json.RawMessage
	if err := json.Unmarshal(v, &list); err != nil {
		return nil, fmt.Errorf("unmarshaling json value for %[2]q into []%[3]s: %%+v", err)
	}
	for i, item := range list {
		inner, err := unmarshal%[3]sImplementation(item)
		if err != nil {
			return nil, fmt.Errorf("unmarshaling implementation for %[3]s item %%d: %%+v", i, err) 
		}
		items = append(items, *inner)
	}
	s.%[1]s = items
}
`, fieldName, fieldDetails.JsonName, referenceType))
				continue
			}

			if fieldDetails.ObjectDefinition.Type == resourcemanager.ReferenceApiObjectDefinitionType {
				// map it directly
				if fieldDetails.ObjectDefinition.ReferenceName == nil {
					return nil, fmt.Errorf("reference was nil: %s", fieldDetails.ObjectDefinition)
				}
				referenceType := *fieldDetails.ObjectDefinition.ReferenceName
				if fieldDetails.Optional {
					lines = append(lines, fmt.Sprintf(`
if v := decoded[%[2]q]; v != nil {
	inner, err := unmarshal%[3]sImplementation(v)
	if err != nil {
		return nil, fmt.Errorf("unmarshaling implementation for %[3]s: %%+v", err) 
	}
	s.%[1]s = inner 
}
`, fieldName, fieldDetails.JsonName, referenceType))
					continue
				}

				lines = append(lines, fmt.Sprintf(`
if v := decoded[%[2]q]; v != nil {
	inner, err := unmarshal%[3]sImplementation(v)
	if err != nil {
		return nil, fmt.Errorf("unmarshaling implementation for %[3]s: %%+v", err) 
	}
	s.%[1]s = *inner 
}
`, fieldName, fieldDetails.JsonName, referenceType))
				continue
			}

			return nil, fmt.Errorf("cannot normalize parent type: %+v", fieldDetails.ObjectDefinition.String())
		}
	}

	// if there's any remaining fields then map those across manually
	if len(fieldsToUnmarshalManually) > 0 {
		lines = append(lines, "// map across the remaining fields")
		for _, fieldName := range fieldsToUnmarshalManually {
			lines = append(lines, fmt.Sprintf(`s.%[1]s = decoded.%[1]s`, fieldName))
		}
	}

	output := fmt.Sprintf(`
var _ json.Unmarshaler = &%[1]s{}

func (s *%[1]s) UnmarshalJSON(bytes []byte) error {
	type alias %[1]s
	var decoded alias
	if err := json.Unmarshal(bytes, &decoded); err != nil {
		return fmt.Errorf("unmarshaling into %[1]s: %%+v", err)
	}
	
	%[2]s

	return nil
}
`, c.name, strings.Join(lines, "\n"))
	return &output, nil
}
