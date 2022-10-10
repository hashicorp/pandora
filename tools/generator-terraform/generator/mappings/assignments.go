package mappings

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var assignmentTypes = map[resourcemanager.MappingDefinitionType]assignmentType{
	resourcemanager.DirectAssignmentMappingDefinitionType: directAssignmentLine{},
	resourcemanager.ManualMappingDefinitionType:           manualAssignmentLine{},
}

type assignmentConstantDetails struct {
	sdkResourceName string
	constantName    string
	constantDetails resourcemanager.ConstantDetails
}

type assignmentType interface {
	// assignmentForCreateUpdateMapping returns the Create/Update assignment line for this mapping type
	assignmentForCreateUpdateMapping(mapping resourcemanager.FieldMappingDefinition, schemaModel resourcemanager.TerraformSchemaModelDefinition, sdkModel resourcemanager.ModelDetails, sdkConstant *assignmentConstantDetails) (*string, error)

	// assignmentForReadMapping returns the Read assignment line for this mapping type
	assignmentForReadMapping(mapping resourcemanager.FieldMappingDefinition, schemaModel resourcemanager.TerraformSchemaModelDefinition, sdkModel resourcemanager.ModelDetails, sdkConstant *assignmentConstantDetails) (*string, error)
}

func (m *Mappings) assignmentCreateUpdateLinesForMappings(mappings []resourcemanager.FieldMappingDefinition) (*string, error) {
	lines := make([]string, 0)

	for _, mapping := range mappings {
		assignment, ok := assignmentTypes[mapping.Type]
		if !ok {
			return nil, fmt.Errorf("internal-error: missing assignment type for type %q", mapping.Type)
		}

		schemaModel, ok := m.schemaModels[mapping.From.SchemaModelName]
		if !ok {
			return nil, fmt.Errorf("the schema model %q referenced in mapping was not found", mapping.From.SchemaModelName)
		}
		sdkModel, ok := m.sdkModels[mapping.To.SdkModelName]
		if !ok {
			return nil, fmt.Errorf("the SDK Model %q referenced in mapping was not found", mapping.To.SdkModelName)
		}

		sdkFieldName, err := singleFieldNameFromFieldPath(mapping.To.SdkFieldPath)
		if err != nil {
			return nil, fmt.Errorf("finding single field name from field path %q: %+v", mapping.To.SdkFieldPath, err)
		}
		sdkField, ok := sdkModel.Fields[*sdkFieldName]
		if !ok {
			return nil, fmt.Errorf("the SDK Model %q Field %q was not found", mapping.To.SdkModelName, *sdkFieldName)
		}

		var sdkConstantName *string
		if sdkField.ObjectDefinition.Type == resourcemanager.ReferenceApiObjectDefinitionType {
			if sdkField.ObjectDefinition.ReferenceName == nil {
				return nil, fmt.Errorf("the SDK Model %q Field %q was a reference with no ReferenceName", *sdkFieldName, mapping.To.SdkModelName)
			}

			sdkConstantName = sdkField.ObjectDefinition.ReferenceName
		}
		if sdkField.ObjectDefinition.Type == resourcemanager.ListApiObjectDefinitionType {
			if sdkField.ObjectDefinition.NestedItem == nil {
				return nil, fmt.Errorf("the SDK Model %q Field %q was a List with no NestedItem", *sdkFieldName, mapping.To.SdkModelName)
			}

			// we're only interested if it's a List<Constant> not a List<string>
			if sdkField.ObjectDefinition.NestedItem.Type == resourcemanager.ReferenceApiObjectDefinitionType {
				if sdkField.ObjectDefinition.NestedItem.ReferenceName == nil {
					return nil, fmt.Errorf("the SDK Model %q Field %q was a nested list reference with no ReferenceName", *sdkFieldName, mapping.To.SdkModelName)
				}

				sdkConstantName = sdkField.ObjectDefinition.NestedItem.ReferenceName
			}
		}

		var sdkConstant *assignmentConstantDetails
		if sdkConstantName != nil {
			// NOTE: references to Models are handled by a different Mapping Type, so shouldn't be included here
			constantDetails, ok := m.sdkConstants[*sdkConstantName]
			if !ok {
				return nil, fmt.Errorf("constant %q referenced in SDK Model %q Field %q was not found", *sdkConstantName, *sdkFieldName, mapping.To.SdkModelName)
			}
			sdkConstant = &assignmentConstantDetails{
				sdkResourceName: m.sdkResourceName,
				constantName:    *sdkConstantName,
				constantDetails: constantDetails,
			}
		}

		assignmentLine, err := assignment.assignmentForCreateUpdateMapping(mapping, schemaModel, sdkModel, sdkConstant)
		if err != nil {
			return nil, fmt.Errorf("building create/update assignment line for constant assignment type %q: %+v", mapping.Type, err)
		}
		lines = append(lines, *assignmentLine)
	}

	out := strings.Join(lines, "\n")
	return &out, nil
}

func (m *Mappings) assignmentReadLinesForMappings(mappings []resourcemanager.FieldMappingDefinition) (*string, error) {
	lines := make([]string, 0)

	for _, mapping := range mappings {
		assignment, ok := assignmentTypes[mapping.Type]
		if !ok {
			return nil, fmt.Errorf("internal-error: missing assignment type for type %q", mapping.Type)
		}

		schemaModel, ok := m.schemaModels[mapping.From.SchemaModelName]
		if !ok {
			return nil, fmt.Errorf("the schema model %q referenced in mapping was not found", mapping.From.SchemaModelName)
		}
		sdkModel, ok := m.sdkModels[mapping.To.SdkModelName]
		if !ok {
			return nil, fmt.Errorf("the SDK Model %q referenced in mapping was not found", mapping.To.SdkModelName)
		}

		sdkFieldName, err := singleFieldNameFromFieldPath(mapping.To.SdkFieldPath)
		if err != nil {
			return nil, fmt.Errorf("finding single field name from field path %q: %+v", mapping.To.SdkFieldPath, err)
		}
		sdkField, ok := sdkModel.Fields[*sdkFieldName]
		if !ok {
			return nil, fmt.Errorf("the SDK Model %q Field %q was not found", mapping.To.SdkModelName, *sdkFieldName)
		}

		var sdkConstantName *string
		if sdkField.ObjectDefinition.Type == resourcemanager.ReferenceApiObjectDefinitionType {
			if sdkField.ObjectDefinition.ReferenceName == nil {
				return nil, fmt.Errorf("the SDK Model %q Field %q was a reference with no ReferenceName", *sdkFieldName, mapping.To.SdkModelName)
			}

			sdkConstantName = sdkField.ObjectDefinition.ReferenceName
		}
		if sdkField.ObjectDefinition.Type == resourcemanager.ListApiObjectDefinitionType {
			if sdkField.ObjectDefinition.NestedItem == nil {
				return nil, fmt.Errorf("the SDK Model %q Field %q was a List with no NestedItem", *sdkFieldName, mapping.To.SdkModelName)
			}

			// we're only interested if it's a List<Constant> not a List<string>
			if sdkField.ObjectDefinition.NestedItem.Type == resourcemanager.ReferenceApiObjectDefinitionType {
				if sdkField.ObjectDefinition.NestedItem.ReferenceName == nil {
					return nil, fmt.Errorf("the SDK Model %q Field %q was a nested list reference with no ReferenceName", *sdkFieldName, mapping.To.SdkModelName)
				}

				sdkConstantName = sdkField.ObjectDefinition.NestedItem.ReferenceName
			}
		}

		var sdkConstant *assignmentConstantDetails
		if sdkConstantName != nil {
			// NOTE: references to Models are handled by a different Mapping Type, so shouldn't be included here
			constantDetails, ok := m.sdkConstants[*sdkConstantName]
			if !ok {
				return nil, fmt.Errorf("constant %q referenced in SDK Model %q Field %q was not found", *sdkConstantName, *sdkFieldName, mapping.To.SdkModelName)
			}
			sdkConstant = &assignmentConstantDetails{
				sdkResourceName: m.sdkResourceName,
				constantName:    *sdkConstantName,
				constantDetails: constantDetails,
			}
		}

		assignmentLine, err := assignment.assignmentForReadMapping(mapping, schemaModel, sdkModel, sdkConstant)
		if err != nil {
			return nil, fmt.Errorf("building read assignment line for constant assignment type %q: %+v", mapping.Type, err)
		}
		lines = append(lines, *assignmentLine)
	}

	out := strings.Join(lines, "\n")
	return &out, nil
}
