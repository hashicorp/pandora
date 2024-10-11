// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package generator

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/helpers"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

// TODO: add unit tests covering this

type predicateTemplater struct {
	modelNames       map[string]string
	sortedModelNames []string
	models           map[string]models.SDKModel
}

func (p predicateTemplater) template(data GeneratorData) (*string, error) {
	output := make([]string, 0)
	for _, modelName := range p.sortedModelNames {
		modelNameWithPackage := p.modelNames[modelName]
		model := data.models[modelName]
		predicateStructName := fmt.Sprintf("%sOperationPredicate", modelName)
		if _, hasExisting := data.models[predicateStructName]; hasExisting {
			return nil, fmt.Errorf("existing model %q conflicts with predicate model for %q", predicateStructName, modelName)
		}

		templated, err := p.templateForModel(predicateStructName, modelName, modelNameWithPackage, model)
		if err != nil {
			return nil, err
		}
		output = append(output, *templated)
	}

	copyrightLines, err := copyrightLinesForSource(data.source)
	if err != nil {
		return nil, fmt.Errorf("retrieving copyright lines: %+v", err)
	}

	commonTypesInclude := ""
	if data.commonTypesIncludePath != nil {
		commonTypesInclude = fmt.Sprintf(`import "github.com/hashicorp/go-azure-sdk/%s/%s"`, data.sourceType, *data.commonTypesIncludePath)
	}

	template := fmt.Sprintf(`package %[1]s

%[2]s
%[3]s
%[4]s
`, data.packageName, *copyrightLines, commonTypesInclude, strings.Join(output, "\n"))
	return &template, nil
}

func (p predicateTemplater) templateForModel(predicateStructName string, name, nameWithPackage string, model models.SDKModel) (*string, error) {
	fieldNames := make([]string, 0)

	// unsupported at this time - see https://github.com/hashicorp/pandora/issues/164
	// TODO: look to add support for these, as below
	customTypesToIgnore := map[models.SDKObjectDefinitionType]struct{}{
		models.EdgeZoneSDKObjectDefinitionType:                                {},
		models.SystemAssignedIdentitySDKObjectDefinitionType:                  {},
		models.SystemAndUserAssignedIdentityMapSDKObjectDefinitionType:        {},
		models.SystemAndUserAssignedIdentityListSDKObjectDefinitionType:       {},
		models.LegacySystemAndUserAssignedIdentityListSDKObjectDefinitionType: {},
		models.LegacySystemAndUserAssignedIdentityMapSDKObjectDefinitionType:  {},
		models.SystemOrUserAssignedIdentityMapSDKObjectDefinitionType:         {},
		models.SystemOrUserAssignedIdentityListSDKObjectDefinitionType:        {},
		models.UserAssignedIdentityMapSDKObjectDefinitionType:                 {},
		models.UserAssignedIdentityListSDKObjectDefinitionType:                {},
		models.TagsSDKObjectDefinitionType:                                    {},
		models.SystemDataSDKObjectDefinitionType:                              {},
		models.ZoneSDKObjectDefinitionType:                                    {},
		models.ZonesSDKObjectDefinitionType:                                   {},
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

	// if this is a parent/interface type, for now don't output anything as a part of the predicates
	// but in time we should look to support filtering on the sub-type, or something?
	// issue: https://github.com/hashicorp/pandora/issues/956
	isParentInterface := false
	if model.ParentTypeName == nil && model.FieldNameContainingDiscriminatedValue != nil && model.DiscriminatedValue == nil {
		isParentInterface = true
	}

	matchLines := make([]string, 0)
	structLines := make([]string, 0)
	if !isParentInterface {
		for _, fieldName := range fieldNames {
			fieldVal := model.Fields[fieldName]

			typeInfo, err := helpers.GolangTypeForSDKObjectDefinition(fieldVal.ObjectDefinition, nil, nil)
			if err != nil {
				return nil, fmt.Errorf("determining type information for field %q in model %q with info %q: %+v", fieldName, name, string(fieldVal.ObjectDefinition.Type), err)
			}
			structLines = append(structLines, fmt.Sprintf("\t %[1]s *%[2]s", fieldName, *typeInfo))

			// TODO: support for ReadOnly fields
			if fieldVal.Optional || fieldVal.ReadOnly {
				matchLines = append(matchLines, fmt.Sprintf(`
	if p.%[1]s != nil && (input.%[1]s == nil || *p.%[1]s != *input.%[1]s) {
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
	}

	template := fmt.Sprintf(` 
type %[1]s struct {
%[3]s
}

func (p %[1]s) Matches(input %[2]s) bool {
%[4]s

	return true
}
`, predicateStructName, nameWithPackage, strings.Join(structLines, "\n"), strings.Join(matchLines, "\n"))
	return &template, nil
}
