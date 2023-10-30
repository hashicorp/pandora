package dataapigeneratorjson

import (
	"fmt"
	"sort"

	dataApiModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigeneratorjson/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func mapTerraformSchemaMappings(input resourcemanager.MappingDefinition) (*dataApiModels.TerraformMappingDefinition, error) {
	output := dataApiModels.TerraformMappingDefinition{}

	fieldMappings := make([]dataApiModels.TerraformFieldMappingDefinition, 0)
	modelToModelMappings := make([]dataApiModels.TerraformModelToModelMappingDefinition, 0)
	for _, item := range input.Fields {
		switch item.Type {
		case resourcemanager.DirectAssignmentMappingDefinitionType:
			{
				// DirectAssignment Mappings come solely from the Mapping themselves
				fieldMappings = append(fieldMappings, dataApiModels.TerraformFieldMappingDefinition{
					Type: dataApiModels.DirectAssignmentTerraformFieldMappingDefinitionType,
					DirectAssignment: &dataApiModels.TerraformFieldMappingDirectAssignmentDefinition{
						SchemaModelName: item.DirectAssignment.SchemaModelName,
						SchemaFieldPath: item.DirectAssignment.SchemaFieldPath,
						SdkModelName:    item.DirectAssignment.SdkModelName,
						SdkFieldPath:    item.DirectAssignment.SdkFieldPath,
					},
				})
				continue
			}

		case resourcemanager.ModelToModelMappingDefinitionType:
			{
				// ModelToModel mappings need to be output both for Fields and for the Models themselves
				// this is because a ModelToModel mapping must exist from the Schema Model to the SDK Model
				// but also from a given Schema Field to a given SDK Model.
				//
				// This allows both the mapping function between two models to be generated (the `ModelToModelMappings`)
				// and the mapping between a given Schema Field and an SDK Model (so that we know to call the
				// mapping function defined in the `ModelToModelMappings`).
				fieldMappings = append(fieldMappings, dataApiModels.TerraformFieldMappingDefinition{
					Type: dataApiModels.ModelToModelTerraformFieldMappingDefinitionType,
					ModelToModel: &dataApiModels.TerraformFieldMappingModelToModelDefinition{
						SchemaModelName: item.ModelToModel.SchemaModelName,
						SdkModelName:    item.ModelToModel.SdkModelName,
						SdkFieldName:    item.ModelToModel.SdkFieldName,
					},
				})
				// NOTE: any duplications get removed below - so this is safe for now
				modelToModelMappings = append(modelToModelMappings, dataApiModels.TerraformModelToModelMappingDefinition{
					SchemaModelName: item.ModelToModel.SchemaModelName,
					SdkModelName:    item.ModelToModel.SdkModelName,
				})
				continue
			}

		case resourcemanager.ManualMappingDefinitionType:
			{
				fieldMappings = append(fieldMappings, dataApiModels.TerraformFieldMappingDefinition{
					Type: dataApiModels.ManualTerraformFieldMappingDefinitionType,
					Manual: &dataApiModels.TerraformFieldManualMappingDefinition{
						MethodName: item.Manual.MethodName,
					},
				})
			}

		default:
			{
				return nil, fmt.Errorf("internal-error: missing mapping implementation for %q", string(item.Type))
			}
		}
	}
	for _, item := range input.ModelToModels {
		// NOTE: any duplications get removed below
		modelToModelMappings = append(modelToModelMappings, dataApiModels.TerraformModelToModelMappingDefinition{
			SchemaModelName: item.SchemaModelName,
			SdkModelName:    item.SdkModelName,
		})
	}

	// Now that we've collated everything, we should sort the keys in the output
	// to prevent superfluous reordering between regenerations
	outputFieldMappings, err := orderFieldMappings(fieldMappings)
	if err != nil {
		return nil, fmt.Errorf("ordering the field mappings: %+v", err)
	}
	if len(*outputFieldMappings) > 0 {
		output.FieldMappings = outputFieldMappings
	}
	modelToModelMappings = uniqueAndSortModelToModelMappings(modelToModelMappings)
	if len(modelToModelMappings) > 0 {
		output.ModelToModelMappings = &modelToModelMappings
	}

	// Finally ResourceId Mappings are between a given (root-level) Schema Field and a Resource ID Segment
	resourceIdMappings := mapTerraformSchemaResourceIdMappings(input.ResourceId)
	if len(resourceIdMappings) > 0 {
		output.ResourceIdMappings = &resourceIdMappings
	}

	return &output, nil
}

func mapTerraformSchemaResourceIdMappings(input []resourcemanager.ResourceIdMappingDefinition) []dataApiModels.TerraformResourceIdMappingDefinition {
	// we need the ordering to be consistent else to avoid noisy regenerations, so let's order this on one of the keys
	schemaFieldNames := make([]string, 0)
	schemaFieldNamesToResourceIdMappings := make(map[string]resourcemanager.ResourceIdMappingDefinition)
	for _, item := range input {
		schemaFieldNames = append(schemaFieldNames, item.SchemaFieldName)
		schemaFieldNamesToResourceIdMappings[item.SchemaFieldName] = item
	}
	sort.Strings(schemaFieldNames)

	output := make([]dataApiModels.TerraformResourceIdMappingDefinition, 0)
	for _, schemaFieldName := range schemaFieldNames {
		resourceIdMapping := schemaFieldNamesToResourceIdMappings[schemaFieldName]
		output = append(output, dataApiModels.TerraformResourceIdMappingDefinition{
			SchemaFieldName:    resourceIdMapping.SchemaFieldName,
			SegmentName:        resourceIdMapping.SegmentName,
			ParsedFromParentId: resourceIdMapping.ParsedFromParentID,
		})
	}
	return output
}

func orderFieldMappings(input []dataApiModels.TerraformFieldMappingDefinition) (*[]dataApiModels.TerraformFieldMappingDefinition, error) {
	keys := make([]string, 0)
	keysToValues := make(map[string]dataApiModels.TerraformFieldMappingDefinition)
	for _, item := range input {
		key := ""
		switch item.Type {
		case dataApiModels.DirectAssignmentTerraformFieldMappingDefinitionType:
			{
				key = fmt.Sprintf("%s-%s-%s-%s-%s", string(item.Type), item.DirectAssignment.SchemaModelName, item.DirectAssignment.SchemaFieldPath, item.DirectAssignment.SdkModelName, item.DirectAssignment.SdkFieldPath)
			}

		case dataApiModels.ModelToModelTerraformFieldMappingDefinitionType:
			{
				key = fmt.Sprintf("%s-%s-%s-%s", string(item.Type), item.ModelToModel.SchemaModelName, item.ModelToModel.SdkModelName, item.ModelToModel.SdkFieldName)
			}

		case dataApiModels.ManualTerraformFieldMappingDefinitionType:
			{
				key = fmt.Sprintf("%s-%s", string(item.Type), item.Manual.MethodName)
			}

		default:
			{
				// the likelihood of us getting here without being caught above is low, and so would
				// only happen during development - whilst we could panic it's probably easiest to
				// reuse the same error as above so both get fixed concurrently.
				return nil, fmt.Errorf("internal-error: missing mapping implementation for %q", string(item.Type))
			}
		}

		// using this key format means we'll also de-dupe this slice at the same time
		keys = append(keys, key)
		keysToValues[key] = item
	}
	sort.Strings(keys)

	output := make([]dataApiModels.TerraformFieldMappingDefinition, 0)
	for _, key := range keys {
		value := keysToValues[key]
		output = append(output, value)
	}
	return &output, nil
}

func uniqueAndSortModelToModelMappings(input []dataApiModels.TerraformModelToModelMappingDefinition) []dataApiModels.TerraformModelToModelMappingDefinition {
	keys := make([]string, 0)
	keysToValues := make(map[string]dataApiModels.TerraformModelToModelMappingDefinition)
	for _, item := range input {
		// using this key format means we'll also de-dupe this slice at the same time
		key := fmt.Sprintf("%s-%s", item.SchemaModelName, item.SdkModelName)
		keys = append(keys, key)
		keysToValues[key] = item
	}
	sort.Strings(keys)

	output := make([]dataApiModels.TerraformModelToModelMappingDefinition, 0)
	for _, key := range keys {
		value := keysToValues[key]
		output = append(output, value)
	}

	return output
}
