package transforms

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/data-api/internal/repositories"
)

var terraformSchemaObjectDefinitionTypes = map[repositories.TerraformSchemaFieldType]models.TerraformSchemaFieldType{
	// Simple Types
	repositories.BooleanTerraformSchemaObjectDefinitionType:  models.TerraformSchemaFieldTypeBoolean,
	repositories.DateTimeTerraformSchemaObjectDefinitionType: models.TerraformSchemaFieldTypeDateTime,
	repositories.FloatTerraformSchemaObjectDefinitionType:    models.TerraformSchemaFieldTypeFloat,
	repositories.IntegerTerraformSchemaObjectDefinitionType:  models.TerraformSchemaFieldTypeInteger,
	repositories.StringTerraformSchemaObjectDefinitionType:   models.TerraformSchemaFieldTypeString,

	// Complex Types
	repositories.DictionaryTerraformSchemaObjectDefinitionType:    models.TerraformSchemaFieldTypeDictionary,
	repositories.ListTerraformSchemaObjectDefinitionType:          models.TerraformSchemaFieldTypeList,
	repositories.LocationTerraformSchemaObjectDefinitionType:      models.TerraformSchemaFieldTypeLocation,
	repositories.ReferenceTerraformSchemaObjectDefinitionType:     models.TerraformSchemaFieldTypeReference,
	repositories.ResourceGroupTerraformSchemaObjectDefinitionType: models.TerraformSchemaFieldTypeResourceGroup,
	repositories.SetTerraformSchemaObjectDefinitionType:           models.TerraformSchemaFieldTypeSet,

	// Common Schema
	repositories.EdgeZoneTerraformSchemaObjectDefinitionType:                      models.TerraformSchemaFieldTypeEdgeZone,
	repositories.SystemAssignedIdentityTerraformSchemaObjectDefinitionType:        models.TerraformSchemaFieldTypeIdentitySystemAssigned,
	repositories.SystemAndUserAssignedIdentityTerraformSchemaObjectDefinitionType: models.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned,
	repositories.SystemOrUserAssignedIdentityTerraformSchemaObjectDefinitionType:  models.TerraformSchemaFieldTypeIdentitySystemOrUserAssigned,
	repositories.TagsTerraformSchemaObjectDefinitionType:                          models.TerraformSchemaFieldTypeTags,
	repositories.UserAssignedIdentityTerraformSchemaObjectDefinitionType:          models.TerraformSchemaFieldTypeIdentityUserAssigned,
	repositories.ZoneTerraformSchemaObjectDefinitionType:                          models.TerraformSchemaFieldTypeZone,
	repositories.ZonesTerraformSchemaObjectDefinitionType:                         models.TerraformSchemaFieldTypeZones,
}

func mapTerraformSchemaFieldObjectDefinition(input repositories.TerraformSchemaFieldObjectDefinition) (*models.TerraformSchemaFieldObjectDefinition, error) {
	mappedType, ok := terraformSchemaObjectDefinitionTypes[input.Type]
	if !ok {
		return nil, fmt.Errorf("internal-error: missing mapping for TerraformSchemaObjectDefinitionType %q", string(input.Type))
	}

	output := models.TerraformSchemaFieldObjectDefinition{
		NestedObject:  nil,
		ReferenceName: input.ReferenceName,
		Type:          mappedType,
	}
	if input.NestedObject != nil {
		nestedItem, err := mapTerraformSchemaFieldObjectDefinition(*input.NestedObject)
		if err != nil {
			return nil, fmt.Errorf("mapping ObjectDefinition: %+v", err)
		}
		output.NestedObject = nestedItem
	}

	return &output, nil
}
