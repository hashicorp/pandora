package generator

import (
	"fmt"
	"sort"
	"strings"
	"time"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

// TODO: dynamic imports

func (s *ServiceGenerator) models(data ServiceGeneratorData) error {
	if len(data.models) == 0 {
		return nil
	}

	for modelName, model := range data.models {
		// model_{name}.go
		// arguably we could enhance this to make `MyThing` be `my_thing` but this is fine for now
		fileName := fmt.Sprintf("model_%s.go", strings.ToLower(modelName))
		gen := modelsTemplater{
			name:  modelName,
			model: model,
		}
		if err := s.writeToPath(data.outputPath, fileName, gen, data); err != nil {
			return fmt.Errorf("templating model for %q: %+v", modelName, err)
		}
	}

	return nil
}

var _ templater = modelsTemplater{}

type modelsTemplater struct {
	name  string
	model resourcemanager.ModelDetails
}

func (c modelsTemplater) template(data ServiceGeneratorData) (*string, error) {
	fields := make([]string, 0)
	for fieldName := range c.model.Fields {
		fields = append(fields, fieldName)
	}
	sort.Strings(fields)

	lines := make([]string, 0)
	methods := make([]string, 0)
	requiresUnmarshalFunc := false
	for _, fieldName := range fields {
		fieldDetails := c.model.Fields[fieldName]
		fieldTypeName := "FIXME"
		fieldTypeVal, err := golangTypeNameForObjectDefinition(fieldDetails.ObjectDefinition)
		if err != nil {
			return nil, fmt.Errorf("determining type information for %q: %+v", fieldName, err)
		}
		fieldTypeName = *fieldTypeVal

		structLine, err := c.structLineForField(fieldName, fieldTypeName, fieldDetails)
		if err != nil {
			return nil, err
		}

		if fieldDetails.DateFormat != nil {
			dateFormat := dateFormatString(*fieldDetails.DateFormat)

			// Get{Name}AsTime method for getting *time.Time from a string
			methods = append(methods, fmt.Sprintf("\tfunc (o %[1]s) Get%[2]sAsTime() (*time.Time, error) {", c.name, fieldName))
			if fieldDetails.Optional {
				methods = append(methods, fmt.Sprintf("\t\tif o.%s == nil {", fieldName))
				methods = append(methods, fmt.Sprintf("\t\t\treturn nil, nil"))
				methods = append(methods, fmt.Sprintf("\t\t}"))
				methods = append(methods, fmt.Sprintf("\t\treturn formatting.ParseAsDateFormat(o.%s, %q)", fieldName, dateFormat))
			} else {
				methods = append(methods, fmt.Sprintf("\t\treturn formatting.ParseAsDateFormat(&o.%s, %q)", fieldName, dateFormat))
			}

			methods = append(methods, fmt.Sprintf("\t}\n"))

			// Set{Name}AsTime method - for setting time.Time -> string
			methods = append(methods, fmt.Sprintf("\tfunc (o %[1]s) Set%[2]sAsTime(input time.Time) {", c.name, fieldName))
			methods = append(methods, fmt.Sprintf("\t\tformatted := input.Format(%q)", dateFormat))
			if fieldDetails.Optional {
				methods = append(methods, fmt.Sprintf("\t\to.%s = &formatted", fieldName))
			} else {
				methods = append(methods, fmt.Sprintf("\t\to.%s = formatted", fieldName))
			}
			methods = append(methods, fmt.Sprintf("\t}\n"))
		}

		if fieldDetails.IsTypeHint {
			requiresUnmarshalFunc = true
		}

		if c.model.TypeHintIn != nil && *c.model.TypeHintIn == fieldName {
			// this isn't user configurable (and is hard-coded) so there's no point outputting this
			continue
		}

		lines = append(lines, *structLine)
	}

	if requiresUnmarshalFunc {
		unmarshalFunc, err := c.unmarshalerFunc()
		if err != nil {
			return nil, err
		}
		methods = append(methods, *unmarshalFunc)
	}

	// if this is an Abstract/Type Hint, we only output the interface with the helper func
	if c.model.TypeHintIn != nil && c.model.ParentTypeName == nil {
		unmarshalFunc, err := c.unmarshalerFuncForParentClass(data)
		if err != nil {
			return nil, err
		}

		template := fmt.Sprintf(`package %[1]s

import (
	"time"

	"github.com/hashicorp/go-azure-helpers/formatting"
)

type %[2]s interface {
}

%[3]s
`, data.packageName, c.name, *unmarshalFunc)
		return &template, nil
	}

	if c.model.TypeHintIn != nil {
		// this'll only be an implementation/child so this can generate the marshaler func
		marshalFunc, err := c.marshalFuncForChildClass()
		if err != nil {
			return nil, err
		}
		methods = append(methods, *marshalFunc)
	}

	validationCode := ""
	// TODO: support for validation

	template := fmt.Sprintf(`package %[1]s

import (
	"time"

	"github.com/hashicorp/go-azure-helpers/formatting"
	"github.com/hashicorp/terraform-provider-azurerm/internal/identity"
)

type %[2]s struct {
%[3]s
}

%[4]s
%[5]s
`, data.packageName, c.name, strings.Join(lines, "\n"), validationCode, strings.Join(methods, "\n"))
	return &template, nil
}

func (c modelsTemplater) structLineForField(fieldName, fieldType string, fieldDetails resourcemanager.FieldDetails) (*string, error) {
	jsonDetails := fieldDetails.JsonName
	if fieldDetails.Optional {
		fieldType = fmt.Sprintf("*%s", fieldType)
		jsonDetails += ",omitempty"
	}

	line := fmt.Sprintf("\t%s %s `json:\"%s\"`", fieldName, fieldType, jsonDetails)
	return &line, nil
}

func dateFormatString(input resourcemanager.DateFormat) string {
	switch input {
	case resourcemanager.RFC3339:
		return time.RFC3339

	case resourcemanager.RFC3339Nano:
		return time.RFC3339Nano

	default:
		panic(fmt.Errorf("unsupported date format %q", string(input)))
	}
}

func (c modelsTemplater) unmarshalerFunc() (*string, error) {
	sortedFields := make([]string, 0)
	for fieldName := range c.model.Fields {
		sortedFields = append(sortedFields, fieldName)
	}
	sort.Strings(sortedFields)

	fields := make([]string, 0)
	assignments := make([]string, 0)

	// first find all of the non-type hint fields
	for _, fieldName := range sortedFields {
		fieldDetails := c.model.Fields[fieldName]
		if fieldDetails.IsTypeHint {
			continue
		}

		fieldTypeName := "FIXME"
		fieldTypeVal, err := golangTypeNameForObjectDefinition(fieldDetails.ObjectDefinition)
		if err != nil {
			return nil, fmt.Errorf("determining type information for %q: %+v", fieldName, err)
		}
		fieldTypeName = *fieldTypeVal

		structLine, err := c.structLineForField(fieldName, fieldTypeName, fieldDetails)
		if err != nil {
			return nil, err
		}

		fields = append(fields, *structLine)
		assignments = append(assignments, fmt.Sprintf("\tc.%[1]s = intermediate.%[1]s", fieldName))
	}

	// then output the TypeHint's as `json.RawMessage`
	for _, fieldName := range sortedFields {
		fieldDetails := c.model.Fields[fieldName]
		if !fieldDetails.IsTypeHint {
			continue
		}

		typeName, err := golangTypeNameForObjectDefinition(fieldDetails.ObjectDefinition)
		if err != nil {
			return nil, fmt.Errorf("determining golang type name: %+v", err)
		}

		if fieldDetails.ObjectDefinition.Type == resourcemanager.ListApiObjectDefinitionType {

			structLine, err := c.structLineForField(fieldName, "[]json.RawMessage", fieldDetails)
			if err != nil {
				return nil, err
			}

			fields = append(fields, *structLine)
			if fieldDetails.Optional {
				assignments = append(assignments, fmt.Sprintf(`
	if *intermediate.%[1]s != nil {
		%[2]ss := make([]%[3]s, 0)
		for _, val := range *intermediate.%[1]s {
			%[2]s, err := unmarshal%[3]s(val)
			if err != nil {
				return fmt.Errorf("unmarshaling %[2]s: %%+v", err)
			}
			%[2]ss = append(%[2]ss, %[2]s)
		}
		c.%[1]s = %[2]ss
	}
`, fieldName, fieldDetails.JsonName, *typeName))
			} else {
				assignments = append(assignments, fmt.Sprintf(`
	%[2]ss := make([]%[3]s, 0)
	for _, val := range *intermediate.%[1]s {
		%[2]s, err := unmarshal%[3]s(val)
		if err != nil {
			return fmt.Errorf("unmarshaling %[2]s: %%+v", err)
		}
		%[2]ss = append(%[2]ss, %[2]s)
	}
	c.%[1]s = %[2]ss
`, fieldName, fieldDetails.JsonName, *typeName))
			}
		} else {
			structLine, err := c.structLineForField(fieldName, "json.RawMessage", fieldDetails)
			if err != nil {
				return nil, err
			}

			fields = append(fields, *structLine)
			if fieldDetails.Optional {
				assignments = append(assignments, fmt.Sprintf(`
	if *intermediate.%[1]s != nil {
		%[2]s, err := unmarshal%[3]s(*intermediate.%[1]s)
		if err != nil {
			return fmt.Errorf("unmarshaling %[2]s: %%+v", err)
		}
		c.%[1]s = %[2]s
	}
`, fieldName, fieldDetails.JsonName, *typeName))
			} else {
				assignments = append(assignments, fmt.Sprintf(`
	%[2]s, err := unmarshal%[3]s(intermediate.%[1]s)
	if err != nil {
		return fmt.Errorf("unmarshaling %[2]s: %%+v", err)
	}
	c.%[1]s = %[2]s
`, fieldName, fieldDetails.JsonName, *typeName))
			}
		}
	}

	template := fmt.Sprintf(`
func (c *%[1]s) UnmarshalJSON(input []byte) error {
	type intermediateType struct {
%[2]s
	}
	var intermediate intermediateType
	if err := json.Unmarshal(input, &intermediate); err != nil {
		return fmt.Errorf("unmarshaling: %%+v", err)
	}

%[3]s

	return nil
}
`, c.name, strings.Join(fields, "\n"), strings.Join(assignments, "\n"))
	return &template, nil
}

func (c modelsTemplater) unmarshalerFuncForParentClass(data ServiceGeneratorData) (*string, error) {
	if c.model.TypeHintIn == nil {
		return nil, fmt.Errorf("TypeHintIn was nil for %q", c.name)
	}

	impls := make(map[string]string, 0) // key: Name / value: value to parse from
	sortedKeys := make([]string, 0)
	for k, v := range data.models {
		if v.ParentTypeName == nil || *v.ParentTypeName != c.name {
			continue
		}

		if v.TypeHintValue == nil {
			return nil, fmt.Errorf("%s has no type hint value", k)
		}

		impls[k] = *v.TypeHintValue
		sortedKeys = append(sortedKeys, k)
	}
	sort.Strings(sortedKeys)

	lines := make([]string, 0)
	for _, key := range sortedKeys {
		value := impls[key]
		lines = append(lines, fmt.Sprintf(`
		case %[1]q: {
			var out %[2]s
			if err := json.Unmarshal(body, &out); err != nil {
				return nil, fmt.Errorf("unmarshalling into %%q: %%+v", %[2]q, err)
			}
			return &out, nil
		}
`, value, key))
	}

	jsonName := ""
	for k, v := range c.model.Fields {
		if k == *c.model.TypeHintIn {
			jsonName = v.JsonName
		}
	}
	if jsonName == "" {
		return nil, fmt.Errorf("couldn't find JsonName for Field %q", *c.model.TypeHintIn)
	}

	structLine := fmt.Sprintf("Type string `json:%q`", jsonName)
	template := fmt.Sprintf(`
func unmarshal%[4]s(body []byte) (%[4]s, error) {
	type intermediateType struct {
		%[1]s
	}
	var intermediate intermediateType
	if err := json.Unmarshal(body, &intermediate); err != nil {
		return nil, fmt.Errorf("decoding: %%+v", err)
	}

	switch intermediate.Type {
%[2]s
	}

	return nil, fmt.Errorf("unknown value for %[3]s: %%q", intermediate.Type)
}
`, structLine, strings.Join(lines, "\n"), *c.model.TypeHintIn, c.name)
	return &template, nil
}

func (c modelsTemplater) marshalFuncForChildClass() (*string, error) {
	if c.model.TypeHintIn == nil {
		return nil, fmt.Errorf("TypeHintIn was nil for %q", c.name)
	}
	if c.model.TypeHintValue == nil {
		return nil, fmt.Errorf("TypeHintValue was nil for %q", c.name)
	}

	sortedFieldNames := make([]string, 0)
	for k := range c.model.Fields {
		sortedFieldNames = append(sortedFieldNames, k)
	}
	sort.Strings(sortedFieldNames)

	fields := make([]string, 0)
	for _, key := range sortedFieldNames {
		jsonName := c.model.Fields[key].JsonName
		if key == *c.model.TypeHintIn {
			fields = append(fields, fmt.Sprintf("%q: %q,", jsonName, *c.model.TypeHintValue))
			continue
		}

		fields = append(fields, fmt.Sprintf("%q: o.%s,", jsonName, key))
	}

	template := fmt.Sprintf(`
var _ json.Marshaler = %[1]s{}

func (o %[1]s) MarshalJSON() ([]byte, error) {
	return json.Marshal(map[string]interface{}{
%[2]s
	})
}
`, c.name, strings.Join(fields, "\n"))
	return &template, nil
}
