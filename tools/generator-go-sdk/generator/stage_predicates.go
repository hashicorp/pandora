package generator

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func (s *ServiceGenerator) predicates(data ServiceGeneratorData) error {
	modelNames := make(map[string]struct{}, 0)
	for _, operation := range data.operations {
		if operation.FieldContainingPaginationDetails == nil {
			continue
		}

		if operation.ResponseObjectName == nil {
			continue
		}

		modelNames[*operation.ResponseObjectName] = struct{}{}
	}

	sortedModelNames := make([]string, 0)
	for k := range modelNames {
		sortedModelNames = append(sortedModelNames, k)
	}
	sort.Strings(sortedModelNames)

	if len(sortedModelNames) == 0 {
		return nil
	}

	templater := predicateTemplater{
		sortedModelNames: sortedModelNames,
		models:           data.models,
	}
	if err := s.writeToPath(data.outputPath, "predicates.go", templater, data); err != nil {
		return fmt.Errorf("templating predicate models: %+v", err)
	}

	return nil
}

type predicateTemplater struct {
	sortedModelNames []string
	models           map[string]resourcemanager.ModelDetails
}

func (p predicateTemplater) template(data ServiceGeneratorData) (*string, error) {
	output := make([]string, 0)
	for _, modelName := range p.sortedModelNames {
		model := data.models[modelName]
		templated, err := p.templateForModel(modelName, model)
		if err != nil {
			return nil, err
		}
		output = append(output, *templated)
	}

	template := fmt.Sprintf(`package %[1]s

%[2]s
`, data.packageName, strings.Join(output, "\n"))
	return &template, nil
}

func (p predicateTemplater) templateForModel(name string, model resourcemanager.ModelDetails) (*string, error) {
	fieldNames := make([]string, 0)
	for name, field := range model.Fields {
		// TODO: add support for these, but this is fine to skip for now
		if field.ListElementType != nil || field.ConstantReferenceName != nil || field.ModelReferenceName != nil {
			continue
		}

		fieldNames = append(fieldNames, name)
	}
	sort.Strings(fieldNames)

	matchLines := make([]string, 0)
	structLines := make([]string, 0)
	for _, fieldName := range fieldNames {
		fieldVal := model.Fields[fieldName]

		typeInfo, err := typeInformationForNativeType(string(fieldVal.Type))
		if err != nil {
			return nil, fmt.Errorf("determining type information for field %q in model %q with info %q: %+v", fieldName, name, string(fieldVal.Type), err)
		}
		structLines = append(structLines, fmt.Sprintf("\t %[1]s *%[2]s", fieldName, *typeInfo))

		if fieldVal.Optional {
			matchLines = append(matchLines, fmt.Sprintf(`
	if p.%[1]s != nil && (input.%[1]s == nil && *p.%[1]s != *input.%[1]s) {
	 	return false
	}
`, fieldName))
		} else {
			matchLines = append(matchLines, fmt.Sprintf(`
	if p.%[1]s != nil && *p.%[1]s != input.%[1]s {
	 	return false
	}
`, fieldName))
		}
	}

	template := fmt.Sprintf(` 
type %[1]sPredicate struct {
%[2]s
}

func (p %[1]sPredicate) Matches(input %[1]s) bool {
%[3]s

	return true
}
`, name, strings.Join(structLines, "\n"), strings.Join(matchLines, "\n"))
	return &template, nil
}
