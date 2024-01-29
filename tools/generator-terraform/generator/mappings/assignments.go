// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package mappings

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var assignmentTypes = map[resourcemanager.MappingDefinitionType]assignmentType{
	resourcemanager.DirectAssignmentMappingDefinitionType: directAssignmentLine{},
	resourcemanager.ModelToModelMappingDefinitionType:     modelToModelAssignmentLine{},
	//resourcemanager.ManualMappingDefinitionType:           manualAssignmentLine{},
}

type assignmentConstantDetails struct {
	apiResourcePackageName string
	constantName           string
	constantDetails        resourcemanager.ConstantDetails
}

type assignmentType interface {
	// assignmentForCreateUpdateMapping returns the Create/Update assignment line for this mapping type
	assignmentForCreateUpdateMapping(mapping resourcemanager.FieldMappingDefinition, schemaModel resourcemanager.TerraformSchemaModelDefinition, sdkModel resourcemanager.ModelDetails, sdkConstant *assignmentConstantDetails, assignmentForReadMapping string) (*string, error)

	// assignmentForReadMapping returns the Read assignment line for this mapping type
	assignmentForReadMapping(mapping resourcemanager.FieldMappingDefinition, schemaModel resourcemanager.TerraformSchemaModelDefinition, sdkModel resourcemanager.ModelDetails, sdkConstant *assignmentConstantDetails, assignmentForReadMapping string) (*string, error)
}

func (m *Mappings) SchemaModelToSdkModelAssignmentLine(mappings []resourcemanager.FieldMappingDefinition) (*string, error) {
	lines := make([]string, 0)

	for _, mapping := range mappings {
		assignment, ok := assignmentTypes[mapping.Type]
		if !ok {
			return nil, fmt.Errorf("internal-error: missing assignment type for type %q", mapping.Type)
		}

		schemaModelName := mapping.SchemaModelName()
		sdkModelName := mapping.SdkModelName()
		sdkFieldPath := mapping.SdkFieldPath()

		schemaModel, ok := m.schemaModels[schemaModelName]
		if !ok {
			return nil, fmt.Errorf("the schema model %q referenced in mapping was not found", schemaModelName)
		}
		sdkModel, ok := m.sdkModels[sdkModelName]
		if !ok {
			return nil, fmt.Errorf("the SDK Model %q referenced in mapping was not found", sdkModelName)
		}

		sdkFieldName, err := singleFieldNameFromFieldPath(sdkFieldPath)
		if err != nil {
			return nil, fmt.Errorf("finding single field name from field path %q: %+v", sdkFieldPath, err)
		}
		sdkField, ok := sdkModel.Fields[*sdkFieldName]
		if !ok {
			return nil, fmt.Errorf("the SDK Model %q Field %q was not found", sdkModelName, *sdkFieldName)
		}

		var sdkConstantName *string
		if sdkField.ObjectDefinition.Type == resourcemanager.ReferenceApiObjectDefinitionType {
			if sdkField.ObjectDefinition.ReferenceName == nil {
				return nil, fmt.Errorf("the SDK Model %q Field %q was a reference with no ReferenceName", *sdkFieldName, sdkModelName)
			}

			sdkConstantName = sdkField.ObjectDefinition.ReferenceName
		}
		if sdkField.ObjectDefinition.Type == resourcemanager.ListApiObjectDefinitionType {
			if sdkField.ObjectDefinition.NestedItem == nil {
				return nil, fmt.Errorf("the SDK Model %q Field %q was a List with no NestedItem", *sdkFieldName, sdkModelName)
			}

			// we're only interested if it's a List<Constant> not a List<string>
			if sdkField.ObjectDefinition.NestedItem.Type == resourcemanager.ReferenceApiObjectDefinitionType {
				if sdkField.ObjectDefinition.NestedItem.ReferenceName == nil {
					return nil, fmt.Errorf("the SDK Model %q Field %q was a nested list reference with no ReferenceName", *sdkFieldName, sdkModelName)
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

		if mapping.ModelToModel != nil {
			if field, ok := sdkModel.Fields[mapping.ModelToModel.SdkFieldName]; ok {
				if field.ObjectDefinition.Type == resourcemanager.RawObjectApiObjectDefinitionType {
					continue
				}
			}
		}

		assignmentLine, err := assignment.assignmentForCreateUpdateMapping(mapping, schemaModel, sdkModel, sdkConstant, m.apiResourcePackageName)
		if err != nil {
			return nil, fmt.Errorf("building create/update assignment line for assignment type %q (Mapping %q): %+v", string(mapping.Type), mapping.String(), err)
		}
		lines = append(lines, *assignmentLine)
	}

	out := strings.Join(lines, "\n")
	return &out, nil
}

func (m *Mappings) SdkModelToSchemaModelAssignmentLine(mappings []resourcemanager.FieldMappingDefinition) (*string, error) {
	lines := make([]string, 0)

	for _, mapping := range mappings {
		assignment, ok := assignmentTypes[mapping.Type]
		if !ok {
			return nil, fmt.Errorf("internal-error: missing assignment type for type %q", mapping.Type)
		}

		schemaModelName := mapping.SchemaModelName()
		sdkModelName := mapping.SdkModelName()
		sdkFieldPath := mapping.SdkFieldPath()

		schemaModel, ok := m.schemaModels[schemaModelName]
		if !ok {
			return nil, fmt.Errorf("the schema model %q referenced in mapping was not found", schemaModelName)
		}
		sdkModel, ok := m.sdkModels[sdkModelName]
		if !ok {
			return nil, fmt.Errorf("the SDK Model %q referenced in mapping was not found", sdkModelName)
		}

		sdkFieldName, err := singleFieldNameFromFieldPath(sdkFieldPath)
		if err != nil {
			return nil, fmt.Errorf("finding single field name from field path %q: %+v", sdkFieldPath, err)
		}
		sdkField, ok := sdkModel.Fields[*sdkFieldName]
		if !ok {
			return nil, fmt.Errorf("the SDK Model %q Field %q was not found", sdkModelName, *sdkFieldName)
		}

		var sdkConstantName *string
		if sdkField.ObjectDefinition.Type == resourcemanager.ReferenceApiObjectDefinitionType {
			if sdkField.ObjectDefinition.ReferenceName == nil {
				return nil, fmt.Errorf("the SDK Model %q Field %q was a reference with no ReferenceName", *sdkFieldName, sdkModelName)
			}

			sdkConstantName = sdkField.ObjectDefinition.ReferenceName
		}
		if sdkField.ObjectDefinition.Type == resourcemanager.ListApiObjectDefinitionType {
			if sdkField.ObjectDefinition.NestedItem == nil {
				return nil, fmt.Errorf("the SDK Model %q Field %q was a List with no NestedItem", *sdkFieldName, sdkModelName)
			}

			// we're only interested if it's a List<Constant> not a List<string>
			if sdkField.ObjectDefinition.NestedItem.Type == resourcemanager.ReferenceApiObjectDefinitionType {
				if sdkField.ObjectDefinition.NestedItem.ReferenceName == nil {
					return nil, fmt.Errorf("the SDK Model %q Field %q was a nested list reference with no ReferenceName", *sdkFieldName, sdkModelName)
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

		if mapping.ModelToModel != nil {
			if field, ok := sdkModel.Fields[mapping.ModelToModel.SdkFieldName]; ok {
				if field.ObjectDefinition.Type == resourcemanager.RawObjectApiObjectDefinitionType {
					continue
				}
			}
		}
		assignmentLine, err := assignment.assignmentForReadMapping(mapping, schemaModel, sdkModel, sdkConstant, m.apiResourcePackageName)
		if err != nil {
			return nil, fmt.Errorf("building read assignment line for constant assignment type %q: %+v", mapping.Type, err)
		}
		lines = append(lines, *assignmentLine)
	}

	out := strings.Join(lines, "\n")
	return &out, nil
}
