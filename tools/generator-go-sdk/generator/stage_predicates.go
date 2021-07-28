package generator

import (
	"fmt"
	"sort"
	"strings"
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
	}
	if err := s.writeToPath(data.outputPath, "predicates.go", templater, data); err != nil {
		return fmt.Errorf("templating predicate models: %+v", err)
	}

	return nil
}

type predicateTemplater struct {
	sortedModelNames []string
}

func (p predicateTemplater) template(data ServiceGeneratorData) (*string, error) {
	output := make([]string, 0)
	for _, modelName := range p.sortedModelNames {
		templated, err := p.templateForModel(modelName)
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

func (p predicateTemplater) templateForModel(name string) (*string, error) {
	template := fmt.Sprintf(` 
type %[1]sPredicate struct {
	// TODO: implement me
}
func (p %[1]sPredicate) Matches(input %[1]s) bool {
	// TODO: implement me
	// if p.Name != nil && input.Name != *p.Name {
	// 	return false
	// }
	return true
}
`, name)
	return &template, nil
}
