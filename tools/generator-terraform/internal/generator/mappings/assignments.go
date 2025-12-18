// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package mappings

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var assignmentTypes = map[models.TerraformFieldMappingDefinitionType]assignmentType{
	models.DirectAssignmentTerraformFieldMappingDefinitionType: directAssignmentLine{},
	models.ModelToModelTerraformFieldMappingDefinitionType:     modelToModelAssignmentLine{},
}

type assignmentConstantDetails struct {
	apiResourcePackageName string
	constantName           string
	constantDetails        models.SDKConstant
}

type assignmentType interface {
	// assignmentForCreateUpdateMapping returns the Create/Update assignment line for this mapping type
	assignmentForCreateUpdateMapping(mapping models.TerraformFieldMappingDefinition, schemaModel models.TerraformSchemaModel, sdkModel models.SDKModel, sdkConstant *assignmentConstantDetails, assignmentForReadMapping string) (*string, error)

	// assignmentForReadMapping returns the Read assignment line for this mapping type
	assignmentForReadMapping(mapping models.TerraformFieldMappingDefinition, schemaModel models.TerraformSchemaModel, sdkModel models.SDKModel, sdkConstant *assignmentConstantDetails, assignmentForReadMapping string) (*string, error)
}

func (m *Mappings) SchemaModelToSdkModelAssignmentLine(mappings []models.TerraformFieldMappingDefinition) (*string, error) {
	lines := make([]string, 0)

	for _, mapping := range mappings {
		summary, err := summaryForMapping(mapping)
		if err != nil {
			return nil, fmt.Errorf("internal-error: populating summary for mapping: %+v", err)
		}

		schemaModel, ok := m.schemaModels[summary.terraformSchemaModelName]
		if !ok {
			return nil, fmt.Errorf("the schema model %q referenced in mapping was not found", summary.terraformSchemaModelName)
		}
		sdkModel, ok := m.sdkModels[summary.sdkModelName]
		if !ok {
			return nil, fmt.Errorf("the SDK Model %q referenced in mapping was not found", summary.sdkModelName)
		}

		sdkField, ok := sdkModel.Fields[summary.sdkFieldName]
		if !ok {
			return nil, fmt.Errorf("the SDK Model %q Field %q was not found", summary.sdkModelName, summary.sdkFieldName)
		}

		var sdkConstantName *string
		if sdkField.ObjectDefinition.Type == models.ReferenceSDKObjectDefinitionType {
			if sdkField.ObjectDefinition.ReferenceName == nil {
				return nil, fmt.Errorf("the SDK Model %q Field %q was a reference with no ReferenceName", summary.sdkModelName, summary.sdkFieldName)
			}

			sdkConstantName = sdkField.ObjectDefinition.ReferenceName
		}
		if sdkField.ObjectDefinition.Type == models.ListSDKObjectDefinitionType {
			if sdkField.ObjectDefinition.NestedItem == nil {
				return nil, fmt.Errorf("the SDK Model %q Field %q was a List with no NestedItem", summary.sdkModelName, summary.sdkFieldName)
			}

			// we're only interested if it's a List<Constant> not a List<string>
			if sdkField.ObjectDefinition.NestedItem.Type == models.ReferenceSDKObjectDefinitionType {
				if sdkField.ObjectDefinition.NestedItem.ReferenceName == nil {
					return nil, fmt.Errorf("the SDK Model %q Field %q was a nested list reference with no ReferenceName", summary.sdkModelName, summary.sdkFieldName)
				}

				sdkConstantName = sdkField.ObjectDefinition.NestedItem.ReferenceName
			}
		}

		var sdkConstant *assignmentConstantDetails
		if sdkConstantName != nil {
			// NOTE: references to Models are handled by a different Mapping Type, so shouldn't be included here
			constantDetails, ok := m.sdkConstants[*sdkConstantName]
			if ok {
				sdkConstant = &assignmentConstantDetails{
					apiResourcePackageName: m.apiResourcePackageName,
					constantName:           *sdkConstantName,
					constantDetails:        constantDetails,
				}
			}
		}

		if _, ok := mapping.(models.TerraformDirectAssignmentFieldMappingDefinition); ok {
			assignmentLine, err := directAssignmentLine{}.assignmentForCreateUpdateMapping(mapping, schemaModel, sdkModel, sdkConstant, m.apiResourcePackageName)
			if err != nil {
				return nil, fmt.Errorf("building create/update direct assignment line for %+v: %+v", summary, err)
			}
			lines = append(lines, *assignmentLine)
			continue
		}

		if v, ok := mapping.(models.TerraformModelToModelFieldMappingDefinition); ok {
			field := sdkModel.Fields[v.ModelToModel.SDKFieldName]
			if field.ObjectDefinition.Type == models.RawObjectSDKObjectDefinitionType {
				continue
			}

			assignmentLine, err := modelToModelAssignmentLine{}.assignmentForCreateUpdateMapping(mapping, schemaModel, sdkModel, sdkConstant, m.apiResourcePackageName)
			if err != nil {
				return nil, fmt.Errorf("building create/update direct assignment line for %+v: %+v", summary, err)
			}
			lines = append(lines, *assignmentLine)
			continue
		}

		return nil, fmt.Errorf("internal-error: missing create/update assignment implementation for %+v", mapping)
	}

	out := strings.Join(lines, "\n")
	return &out, nil
}

func (m *Mappings) SdkModelToSchemaModelAssignmentLine(mappings []models.TerraformFieldMappingDefinition) (*string, error) {
	lines := make([]string, 0)

	for _, mapping := range mappings {
		summary, err := summaryForMapping(mapping)
		if err != nil {
			return nil, fmt.Errorf("internal-error: populating summary for mapping: %+v", err)
		}

		schemaModel, ok := m.schemaModels[summary.terraformSchemaModelName]
		if !ok {
			return nil, fmt.Errorf("the schema model %q referenced in mapping was not found", summary.terraformSchemaModelName)
		}
		sdkModel, ok := m.sdkModels[summary.sdkModelName]
		if !ok {
			return nil, fmt.Errorf("the SDK Model %q referenced in mapping was not found", summary.sdkModelName)
		}

		sdkField, ok := sdkModel.Fields[summary.sdkFieldName]
		if !ok {
			return nil, fmt.Errorf("the SDK Model %q Field %q was not found", summary.sdkModelName, summary.sdkFieldName)
		}

		var sdkConstantName *string
		if sdkField.ObjectDefinition.Type == models.ReferenceSDKObjectDefinitionType {
			if sdkField.ObjectDefinition.ReferenceName == nil {
				return nil, fmt.Errorf("the SDK Model %q Field %q was a reference with no ReferenceName", summary.sdkModelName, summary.sdkFieldName)
			}

			sdkConstantName = sdkField.ObjectDefinition.ReferenceName
		}
		if sdkField.ObjectDefinition.Type == models.ListSDKObjectDefinitionType {
			if sdkField.ObjectDefinition.NestedItem == nil {
				return nil, fmt.Errorf("the SDK Model %q Field %q was a List with no NestedItem", summary.sdkModelName, summary.sdkFieldName)
			}

			// we're only interested if it's a List<Constant> not a List<string>
			if sdkField.ObjectDefinition.NestedItem.Type == models.ReferenceSDKObjectDefinitionType {
				if sdkField.ObjectDefinition.NestedItem.ReferenceName == nil {
					return nil, fmt.Errorf("the SDK Model %q Field %q was a nested list reference with no ReferenceName", summary.sdkModelName, summary.sdkFieldName)
				}

				sdkConstantName = sdkField.ObjectDefinition.NestedItem.ReferenceName
			}
		}

		var sdkConstant *assignmentConstantDetails
		if sdkConstantName != nil {
			// NOTE: references to Models are handled by a different Mapping Type, so shouldn't be included here
			constantDetails, ok := m.sdkConstants[*sdkConstantName]
			if ok {
				sdkConstant = &assignmentConstantDetails{
					apiResourcePackageName: m.apiResourcePackageName,
					constantName:           *sdkConstantName,
					constantDetails:        constantDetails,
				}
			}
		}

		if _, ok := mapping.(models.TerraformDirectAssignmentFieldMappingDefinition); ok {
			assignmentLine, err := directAssignmentLine{}.assignmentForReadMapping(mapping, schemaModel, sdkModel, sdkConstant, m.apiResourcePackageName)
			if err != nil {
				return nil, fmt.Errorf("building read direct assignment line for %+v: %+v", summary, err)
			}
			lines = append(lines, *assignmentLine)
			continue
		}

		if v, ok := mapping.(models.TerraformModelToModelFieldMappingDefinition); ok {
			field := sdkModel.Fields[v.ModelToModel.SDKFieldName]
			if field.ObjectDefinition.Type == models.RawObjectSDKObjectDefinitionType {
				continue
			}

			assignmentLine, err := modelToModelAssignmentLine{}.assignmentForReadMapping(mapping, schemaModel, sdkModel, sdkConstant, m.apiResourcePackageName)
			if err != nil {
				return nil, fmt.Errorf("building read direct assignment line for %+v: %+v", summary, err)
			}
			lines = append(lines, *assignmentLine)
			continue
		}

		return nil, fmt.Errorf("internal-error: missing read assignment implementation for %+v", mapping)
	}

	out := strings.Join(lines, "\n")
	return &out, nil
}

type mappingSummary struct {
	sdkFieldName             string
	sdkModelName             string
	terraformSchemaModelName string
}

func summaryForMapping(input models.TerraformFieldMappingDefinition) (*mappingSummary, error) {
	if v, ok := input.(models.TerraformDirectAssignmentFieldMappingDefinition); ok {
		return &mappingSummary{
			sdkFieldName:             v.DirectAssignment.SDKFieldName,
			sdkModelName:             v.DirectAssignment.SDKModelName,
			terraformSchemaModelName: v.DirectAssignment.TerraformSchemaModelName,
		}, nil
	}

	if v, ok := input.(models.TerraformModelToModelFieldMappingDefinition); ok {
		return &mappingSummary{
			sdkFieldName:             v.ModelToModel.SDKFieldName,
			sdkModelName:             v.ModelToModel.SDKModelName,
			terraformSchemaModelName: v.ModelToModel.TerraformSchemaModelName,
		}, nil
	}

	return nil, fmt.Errorf("internal-error: unimplemented mapping type %+v", input)
}
