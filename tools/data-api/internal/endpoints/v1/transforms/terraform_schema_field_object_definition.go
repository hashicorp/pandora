package transforms

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/data-api/internal/repositories"
)

var terraformSchemaObjectDefinitionTypes = map[repositories.TerraformSchemaFieldType]models.TerraformSchemaObjectDefinitionType{
	// Simple Types
	repositories.BooleanTerraformSchemaObjectDefinitionType:  models.BooleanTerraformSchemaObjectDefinitionType,
	repositories.DateTimeTerraformSchemaObjectDefinitionType: models.DateTimeTerraformSchemaObjectDefinitionType,
	repositories.FloatTerraformSchemaObjectDefinitionType:    models.FloatTerraformSchemaObjectDefinitionType,
	repositories.IntegerTerraformSchemaObjectDefinitionType:  models.IntegerTerraformSchemaObjectDefinitionType,
	repositories.StringTerraformSchemaObjectDefinitionType:   models.StringTerraformSchemaObjectDefinitionType,

	// Complex Types
	repositories.DictionaryTerraformSchemaObjectDefinitionType:    models.DictionaryTerraformSchemaObjectDefinitionType,
	repositories.ListTerraformSchemaObjectDefinitionType:          models.ListTerraformSchemaObjectDefinitionType,
	repositories.LocationTerraformSchemaObjectDefinitionType:      models.LocationTerraformSchemaObjectDefinitionType,
	repositories.ReferenceTerraformSchemaObjectDefinitionType:     models.ReferenceTerraformSchemaObjectDefinitionType,
	repositories.ResourceGroupTerraformSchemaObjectDefinitionType: models.ResourceGroupTerraformSchemaObjectDefinitionType,
	repositories.SetTerraformSchemaObjectDefinitionType:           models.SetTerraformSchemaObjectDefinitionType,

	// Common Schema
	repositories.EdgeZoneTerraformSchemaObjectDefinitionType:                      models.EdgeZoneTerraformSchemaObjectDefinitionType,
	repositories.SystemAssignedIdentityTerraformSchemaObjectDefinitionType:        models.SystemAssignedIdentityTerraformSchemaObjectDefinitionType,
	repositories.SystemAndUserAssignedIdentityTerraformSchemaObjectDefinitionType: models.SystemAndUserAssignedIdentityTerraformSchemaObjectDefinitionType,
	repositories.SystemOrUserAssignedIdentityTerraformSchemaObjectDefinitionType:  models.SystemOrUserAssignedIdentityTerraformSchemaObjectDefinitionType,
	repositories.TagsTerraformSchemaObjectDefinitionType:                          models.TagsTerraformSchemaObjectDefinitionType,
	repositories.UserAssignedIdentityTerraformSchemaObjectDefinitionType:          models.UserAssignedIdentityTerraformSchemaObjectDefinitionType,
	repositories.ZoneTerraformSchemaObjectDefinitionType:                          models.ZoneTerraformSchemaObjectDefinitionType,
	repositories.ZonesTerraformSchemaObjectDefinitionType:                         models.ZonesTerraformSchemaObjectDefinitionType,
}

func mapTerraformSchemaFieldObjectDefinition(input repositories.TerraformSchemaFieldObjectDefinition) (*models.TerraformSchemaObjectDefinition, error) {
	mappedType, ok := terraformSchemaObjectDefinitionTypes[input.Type]
	if !ok {
		return nil, fmt.Errorf("internal-error: missing mapping for TerraformSchemaObjectDefinitionType %q", string(input.Type))
	}

	output := models.TerraformSchemaObjectDefinition{
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
