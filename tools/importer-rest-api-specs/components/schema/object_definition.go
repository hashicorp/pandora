package schema

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var apiObjectDefinitionTypesToFieldObjectDefinitionTypes = map[resourcemanager.ApiObjectDefinitionType]resourcemanager.TerraformSchemaFieldType{
	resourcemanager.BooleanApiObjectDefinitionType: resourcemanager.TerraformSchemaFieldTypeBoolean,
	//resourcemanager.CsvApiObjectDefinitionType:  resourcemanager.TerraformSchemaFieldTypeCsv, // TODO: implement
	resourcemanager.DateTimeApiObjectDefinitionType: resourcemanager.TerraformSchemaFieldTypeDateTime,
	//resourcemanager.DictionaryApiObjectDefinitionType:  resourcemanager.TerraformSchemaFieldTypeDictionary, // TODO: implement
	resourcemanager.IntegerApiObjectDefinitionType:   resourcemanager.TerraformSchemaFieldTypeInteger,
	resourcemanager.FloatApiObjectDefinitionType:     resourcemanager.TerraformSchemaFieldTypeFloat,
	resourcemanager.ListApiObjectDefinitionType:      resourcemanager.TerraformSchemaFieldTypeList,
	resourcemanager.ReferenceApiObjectDefinitionType: resourcemanager.TerraformSchemaFieldTypeReference,
	resourcemanager.StringApiObjectDefinitionType:    resourcemanager.TerraformSchemaFieldTypeString,

	// Custom Types
	resourcemanager.EdgeZoneApiObjectDefinitionType:                                resourcemanager.TerraformSchemaFieldTypeEdgeZone,
	resourcemanager.LocationApiObjectDefinitionType:                                resourcemanager.TerraformSchemaFieldTypeLocation,
	resourcemanager.SystemAssignedIdentityApiObjectDefinitionType:                  resourcemanager.TerraformSchemaFieldTypeIdentitySystemAssigned,
	resourcemanager.SystemAndUserAssignedIdentityListApiObjectDefinitionType:       resourcemanager.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned,
	resourcemanager.SystemAndUserAssignedIdentityMapApiObjectDefinitionType:        resourcemanager.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned,
	resourcemanager.LegacySystemAndUserAssignedIdentityListApiObjectDefinitionType: resourcemanager.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned,
	resourcemanager.LegacySystemAndUserAssignedIdentityMapApiObjectDefinitionType:  resourcemanager.TerraformSchemaFieldTypeIdentitySystemAndUserAssigned,
	resourcemanager.SystemOrUserAssignedIdentityListApiObjectDefinitionType:        resourcemanager.TerraformSchemaFieldTypeIdentitySystemOrUserAssigned,
	resourcemanager.SystemOrUserAssignedIdentityMapApiObjectDefinitionType:         resourcemanager.TerraformSchemaFieldTypeIdentitySystemOrUserAssigned,
	resourcemanager.UserAssignedIdentityListApiObjectDefinitionType:                resourcemanager.TerraformSchemaFieldTypeIdentityUserAssigned,
	resourcemanager.UserAssignedIdentityMapApiObjectDefinitionType:                 resourcemanager.TerraformSchemaFieldTypeIdentityUserAssigned,
	resourcemanager.TagsApiObjectDefinitionType:                                    resourcemanager.TerraformSchemaFieldTypeTags,
	resourcemanager.ZoneApiObjectDefinitionType:                                    resourcemanager.TerraformSchemaFieldTypeZone,
	resourcemanager.ZonesApiObjectDefinitionType:                                   resourcemanager.TerraformSchemaFieldTypeZones,
	// NOTE: we intentionally don't implement SystemData since it's not exposed at this time
}

func (b Builder) convertToFieldObjectDefinition(modelPrefix string, input resourcemanager.ApiObjectDefinition) (*resourcemanager.TerraformSchemaFieldObjectDefinition, error) {
	out := resourcemanager.TerraformSchemaFieldObjectDefinition{}

	var isConstant bool
	var constant resourcemanager.ConstantDetails
	if input.ReferenceName != nil {
		reference := *input.ReferenceName
		if constant, isConstant = b.constants[reference]; !isConstant {
			// models are prefixed to be globally unique
			reference = fmt.Sprintf("%s%s", modelPrefix, reference)
		} else {
			switch constant.Type {
			case resourcemanager.StringConstant:
				out.Type = resourcemanager.TerraformSchemaFieldTypeString
			case resourcemanager.IntegerConstant:
				out.Type = resourcemanager.TerraformSchemaFieldTypeInteger
			case resourcemanager.FloatConstant:
				out.Type = resourcemanager.TerraformSchemaFieldTypeFloat
			default:
				return nil, fmt.Errorf("constant has unknown or unsupported type: %+v", constant.Type)
			}
		}
		out.ReferenceName = &reference
	}

	if input.NestedItem != nil {
		nested, err := b.convertToFieldObjectDefinition(modelPrefix, *input.NestedItem)
		if err != nil {
			return nil, fmt.Errorf("converting nested item: %+v", err)
		}
		out.NestedObject = nested
	}

	if !isConstant {
		v, ok := apiObjectDefinitionTypesToFieldObjectDefinitionTypes[input.Type]
		if !ok {
			return nil, fmt.Errorf("internal-error: missing object definition mapping for type %q", string(input.Type))
		}
		out.Type = v
	}

	return &out, nil
}
