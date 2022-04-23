package generator

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

type predicateTemplater struct {
	sortedModelNames []string
	models           map[string]resourcemanager.ModelDetails
}

func (p predicateTemplater) template(data ServiceGeneratorData) (*string, error) {
	output := make([]string, 0)
	for _, modelName := range p.sortedModelNames {
		model := data.models[modelName]
		predicateStructName := fmt.Sprintf("%sOperationPredicate", modelName)
		if _, hasExisting := data.models[predicateStructName]; hasExisting {
			return nil, fmt.Errorf("existing model %q conflicts with predicate model for %q", predicateStructName, modelName)
		}

		templated, err := p.templateForModel(predicateStructName, modelName, model)
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

func (p predicateTemplater) templateForModel(predicateStructName string, name string, model resourcemanager.ModelDetails) (*string, error) {
	fieldNames := make([]string, 0)

	// unsupported at this time - see https://github.com/hashicorp/pandora/issues/164
	// TODO: look to add support for these, as below
	customTypesToIgnore := map[resourcemanager.ApiObjectDefinitionType]struct{}{
		resourcemanager.SystemAssignedIdentityApiObjectDefinitionType:                  {},
		resourcemanager.SystemAndUserAssignedIdentityMapApiObjectDefinitionType:        {},
		resourcemanager.SystemAndUserAssignedIdentityListApiObjectDefinitionType:       {},
		resourcemanager.LegacySystemAndUserAssignedIdentityListApiObjectDefinitionType: {},
		resourcemanager.LegacySystemAndUserAssignedIdentityMapApiObjectDefinitionType:  {},
		resourcemanager.SystemOrUserAssignedIdentityMapApiObjectDefinitionType:         {},
		resourcemanager.SystemOrUserAssignedIdentityListApiObjectDefinitionType:        {},
		resourcemanager.UserAssignedIdentityMapApiObjectDefinitionType:                 {},
		resourcemanager.UserAssignedIdentityListApiObjectDefinitionType:                {},
		resourcemanager.TagsApiObjectDefinitionType:                                    {},
	}

	for name, field := range model.Fields {
		// TODO: add support for these, but this is fine to skip for now
		if field.ObjectDefinition.ReferenceName != nil || field.ObjectDefinition.NestedItem != nil {
			continue
		}

		if _, ok := customTypesToIgnore[field.ObjectDefinition.Type]; ok {
			continue
		}

		fieldNames = append(fieldNames, name)
	}
	sort.Strings(fieldNames)

	matchLines := make([]string, 0)
	structLines := make([]string, 0)
	for _, fieldName := range fieldNames {
		fieldVal := model.Fields[fieldName]

		typeInfo, err := golangTypeNameForObjectDefinition(fieldVal.ObjectDefinition)
		if err != nil {
			return nil, fmt.Errorf("determining type information for field %q in model %q with info %q: %+v", fieldName, name, string(fieldVal.ObjectDefinition.Type), err)
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
type %[1]s struct {
%[3]s
}

func (p %[1]s) Matches(input %[2]s) bool {
%[4]s

	return true
}
`, predicateStructName, name, strings.Join(structLines, "\n"), strings.Join(matchLines, "\n"))
	return &template, nil
}
