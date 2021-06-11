package generator

import (
	"fmt"
	"sort"
	"strings"
)

var _ stage = modelStage{}

type modelStage struct{}

func (m modelStage) applicable(data *Data) bool {
	return data.TopLevelSchema != nil || data.Objects != nil
}

func (m modelStage) filePath(data Data) string {
	return fmt.Sprintf("%s_model.go", data.fileNamePrefix)
}

func (m modelStage) generate(data Data) (*string, error) {
	lines := make([]string, 0)

	if data.TopLevelSchema != nil {
		topLevelCode, err := m.topLevelModelCode(data.ResourceName, data.IsResource, data.TopLevelSchema.Fields)
		if err != nil {
			return nil, fmt.Errorf("generating model for top level model: %+v", err)
		}

		lines = append(lines, *topLevelCode)
	}

	if data.Objects != nil {
		// we're only concerned with models, constants come from the SDK
		sortedModelNames := make([]string, 0)
		for name := range data.Objects.Models {
			sortedModelNames = append(sortedModelNames, name)
		}
		sort.Strings(sortedModelNames)

		for _, name := range sortedModelNames {
			model := data.Objects.Models[name]
			code, err := m.codeForModel(name, model.Fields)
			if err != nil {
				return nil, fmt.Errorf("generating code for model %q: %+v", name, err)
			}

			lines = append(lines, *code)
		}
	}

	contents := fmt.Sprintf(`package %[1]s

%[2]s
`, data.PackageName, strings.Join(lines, "\n"))
	return &contents, nil
}

func (m modelStage) topLevelModelCode(modelName string, isResource bool, input map[string]FieldDefinition) (*string, error) {
	name := fmt.Sprintf("%sResourceModel", modelName)
	if !isResource {
		name = fmt.Sprintf("%sDataSourceModel", modelName)
	}

	return m.codeForModel(name, input)
}

func (m modelStage) codeForModel(name string, fields map[string]FieldDefinition) (*string, error) {
	fieldNames := make([]string, 0)
	for k := range fields {
		fieldNames = append(fieldNames, k)
	}
	sort.Strings(fieldNames)

	codeForFields := make([]string, 0)
	for _, fieldName := range fieldNames {
		field := fields[fieldName]
		fieldType := "string" // TODO: make this dynamic
		codeForFields = append(codeForFields, fmt.Sprintf("\t%[1]s %[2]s `tfschema:%[3]q`", fieldName, fieldType, field.HclLabel))
	}

	contents := fmt.Sprintf(`type %[1]s struct {
%[2]s
}
`, name, strings.Join(codeForFields, "\n"))
	return &contents, nil
}
