package generator

import (
	"fmt"
	"sort"
	"strings"
	"time"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

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
		if err := s.writeToPath(fileName, gen, data); err != nil {
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
	for _, fieldName := range fields {
		fieldDetails := c.model.Fields[fieldName]
		fieldTypeName := "FIXME"
		fieldTypeVal, err := c.typeInformation(fieldDetails)
		if err != nil {
			return nil, fmt.Errorf("determining type information for %q: %+v", fieldName, err)
		}
		fieldTypeName = *fieldTypeVal

		jsonDetails := fieldDetails.JsonName
		if fieldDetails.Optional {
			fieldTypeName = fmt.Sprintf("*%s", fieldTypeName)
			jsonDetails += ",omitempty"
		}

		if fieldDetails.DateFormat != nil {
			dateFormat := dateFormatString(*fieldDetails.DateFormat)

			// Get{Name}AsTime method for getting *time.Time from a string
			methods = append(methods, fmt.Sprintf("\tfunc (m *NestedItem) Get%sAsTime() (*time.Time, error) {", fieldName))
			methods = append(methods, fmt.Sprintf("\t\treturn formatting.ParseAsDateFormat(m.%s, %q)", fieldName, dateFormat))
			methods = append(methods, fmt.Sprintf("\t}\n"))

			// Set{Name}AsTime method - for setting time.Time -> string
			methods = append(methods, fmt.Sprintf("\tfunc (m *NestedItem) Set%sAsTime(input time.Time) {", fieldName))
			methods = append(methods, fmt.Sprintf("\t\tformatted := input.Format(%q)", dateFormat))
			methods = append(methods, fmt.Sprintf("\t\tm.%s = &formatted", fieldName))
			methods = append(methods, fmt.Sprintf("\t}\n"))
		}

		line := fmt.Sprintf("\t%s %s `json:\"%s\"`", fieldName, fieldTypeName, jsonDetails)
		lines = append(lines, line)
	}

	validationCode := ""
	// TODO: support for validation

	template := fmt.Sprintf(`package %[1]s

import "github.com/hashicorp/go-azure-helpers/formatting"

type %[2]s struct {
%[3]s
}

%[4]s
%[5]s
`, data.packageName, c.name, strings.Join(lines, "\n"), validationCode, strings.Join(methods, "\n"))
	return &template, nil
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

func (c modelsTemplater) typeInformation(details resourcemanager.FieldDetails) (*string, error) {
	// TODO: again these are things which should be caught by the validator, so move these up
	// but also leave these here since this is sanity checking a bad API
	if strings.EqualFold(string(details.Type), string(resourcemanager.List)) {
		if details.ListElementType == nil {
			return nil, fmt.Errorf("a ListElementType must be configured for a List")
		}

		typeName := *details.ListElementType
		if strings.EqualFold(*details.ListElementType, string(resourcemanager.Object)) {
			if details.ModelReferenceName == nil {
				return nil, fmt.Errorf("a ModelReferenceName must be configured when using a List")
			}
			typeName = *details.ModelReferenceName
		}

		info := fmt.Sprintf("[]%s", typeName)
		return &info, nil
	}

	if strings.EqualFold(string(details.Type), string(resourcemanager.Constant)) {
		if details.ConstantReferenceName == nil {
			return nil, fmt.Errorf("a ConstantReferenceName must be configured for a Constant")
		}
		return details.ConstantReferenceName, nil
	}

	if strings.EqualFold(string(details.Type), string(resourcemanager.Object)) {
		// Objects are either an Object of a Type (e.g. That Type) or an Object (e.g. a Raw/untyped object)
		// raw is handled via the `native type` below
		if details.ModelReferenceName != nil {
			return details.ModelReferenceName, nil
		}
	}

	return typeInformationForNativeType(details.Type)
}

func typeInformationForNativeType(fieldType resourcemanager.FieldType) (*string, error) {
	var v = func(val string) (*string, error) {
		return &val, nil
	}

	switch strings.ToLower(string(fieldType)) {
	case strings.ToLower(string(resourcemanager.Boolean)):
		return v("bool")

	case strings.ToLower(string(resourcemanager.DateTime)):
		return v("string") // intentional since we have cast methods one way or the other

	case strings.ToLower(string(resourcemanager.Location)):
		return v("string")

	case strings.ToLower(string(resourcemanager.Integer)):
		return v("int64")

	case strings.ToLower(string(resourcemanager.Object)):
		return v("interface{}")

	case strings.ToLower(string(resourcemanager.String)):
		return v("string")

	case strings.ToLower(string(resourcemanager.Tags)):
		return v("map[string]string")

		// TODO: other types
	}

	return v(string(fieldType))
}
