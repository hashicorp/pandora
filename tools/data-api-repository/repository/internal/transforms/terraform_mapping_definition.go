// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"
	"sort"

	repositoryModels "github.com/hashicorp/pandora/tools/data-api-repository/repository/internal/models"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func MapTerraformSchemaMappingsFromRepository(input repositoryModels.TerraformMappingDefinition) (*sdkModels.TerraformMappingDefinition, error) {
	output := sdkModels.TerraformMappingDefinition{
		Fields:        make([]sdkModels.TerraformFieldMappingDefinition, 0),
		ModelToModels: make([]sdkModels.TerraformModelToModelMappingDefinition, 0),
		ResourceID:    make([]sdkModels.TerraformResourceIDMappingDefinition, 0),
	}

	if input.FieldMappings != nil {
		for _, item := range *input.FieldMappings {
			switch item.Type {
			case repositoryModels.DirectAssignmentTerraformFieldMappingDefinitionType:
				{
					output.Fields = append(output.Fields, sdkModels.TerraformDirectAssignmentFieldMappingDefinition{
						DirectAssignment: sdkModels.TerraformDirectAssignmentFieldMappingDefinitionImpl{
							TerraformSchemaModelName: item.DirectAssignment.SchemaModelName,
							TerraformSchemaFieldName: item.DirectAssignment.SchemaFieldPath,
							SDKModelName:             item.DirectAssignment.SdkModelName,
							SDKFieldName:             item.DirectAssignment.SdkFieldPath,
						},
					})
				}

			case repositoryModels.ModelToModelTerraformFieldMappingDefinitionType:
				{
					output.Fields = append(output.Fields, sdkModels.TerraformModelToModelFieldMappingDefinition{
						ModelToModel: sdkModels.TerraformModelToModelFieldMappingDefinitionImpl{
							TerraformSchemaModelName: item.ModelToModel.SchemaModelName,
							SDKModelName:             item.ModelToModel.SdkModelName,
							SDKFieldName:             item.ModelToModel.SdkFieldName,
						},
					})
				}

			default:
				{
					return nil, fmt.Errorf("unimplemented Field Mapping Definition Type %q", string(item.Type))
				}
			}
		}
	}

	if input.ModelToModelMappings != nil {
		for _, item := range *input.ModelToModelMappings {
			output.ModelToModels = append(output.ModelToModels, sdkModels.TerraformModelToModelMappingDefinition{
				SDKModelName:             item.SdkModelName,
				TerraformSchemaModelName: item.SchemaModelName,
			})
		}
	}

	if input.ResourceIdMappings != nil {
		for _, item := range *input.ResourceIdMappings {
			output.ResourceID = append(output.ResourceID, sdkModels.TerraformResourceIDMappingDefinition{
				ParsedFromParentID:       item.ParsedFromParentId,
				SegmentName:              item.SegmentName,
				TerraformSchemaFieldName: item.SchemaFieldName,
			})
		}
	}

	return &output, nil
}

func MapTerraformSchemaMappingsToRepository(input sdkModels.TerraformMappingDefinition) (*repositoryModels.TerraformMappingDefinition, error) {
	output := repositoryModels.TerraformMappingDefinition{}

	fieldMappings := make([]repositoryModels.TerraformFieldMappingDefinition, 0)
	modelToModelMappings := make([]repositoryModels.TerraformModelToModelMappingDefinition, 0)
	for _, item := range input.Fields {
		if v, ok := item.(sdkModels.TerraformDirectAssignmentFieldMappingDefinition); ok {
			// DirectAssignment Mappings come solely from the Mapping themselves
			fieldMappings = append(fieldMappings, repositoryModels.TerraformFieldMappingDefinition{
				Type: repositoryModels.DirectAssignmentTerraformFieldMappingDefinitionType,
				DirectAssignment: &repositoryModels.TerraformFieldMappingDirectAssignmentDefinition{
					// todo remove Schema when https://github.com/hashicorp/pandora/issues/3346 is addressed
					SchemaModelName: fmt.Sprintf("%sSchema", v.DirectAssignment.TerraformSchemaModelName),
					SchemaFieldPath: v.DirectAssignment.TerraformSchemaFieldName,
					SdkModelName:    v.DirectAssignment.SDKModelName,
					SdkFieldPath:    v.DirectAssignment.SDKFieldName,
				},
			})
			// NOTE: any duplications get removed below - so this is safe for now
			modelToModelMappings = append(modelToModelMappings, repositoryModels.TerraformModelToModelMappingDefinition{
				// todo remove Schema when https://github.com/hashicorp/pandora/issues/3346 is addressed
				SchemaModelName: fmt.Sprintf("%sSchema", v.DirectAssignment.TerraformSchemaModelName),
				SdkModelName:    v.DirectAssignment.SDKModelName,
			})
			continue
		}

		if v, ok := item.(sdkModels.TerraformModelToModelFieldMappingDefinition); ok {
			// ModelToModel mappings need to be output both for Fields and for the Models themselves
			// this is because a ModelToModel mapping must exist from the Schema Model to the SDK Model
			// but also from a given Schema Field to a given SDK Model.
			//
			// This allows both the mapping function between two models to be generated (the `ModelToModelMappings`)
			// and the mapping between a given Schema Field and an SDK Model (so that we know to call the
			// mapping function defined in the `ModelToModelMappings`).
			fieldMappings = append(fieldMappings, repositoryModels.TerraformFieldMappingDefinition{
				Type: repositoryModels.ModelToModelTerraformFieldMappingDefinitionType,
				ModelToModel: &repositoryModels.TerraformFieldMappingModelToModelDefinition{
					// todo remove Schema when https://github.com/hashicorp/pandora/issues/3346 is addressed
					SchemaModelName: fmt.Sprintf("%sSchema", v.ModelToModel.TerraformSchemaModelName),
					SdkModelName:    v.ModelToModel.SDKModelName,
					SdkFieldName:    v.ModelToModel.SDKFieldName,
				},
			})
			// NOTE: any duplications get removed below - so this is safe for now
			modelToModelMappings = append(modelToModelMappings, repositoryModels.TerraformModelToModelMappingDefinition{
				// todo remove Schema when https://github.com/hashicorp/pandora/issues/3346 is addressed
				SchemaModelName: fmt.Sprintf("%sSchema", v.ModelToModel.TerraformSchemaModelName),
				SdkModelName:    v.ModelToModel.SDKModelName,
			})
			continue
		}

		return nil, fmt.Errorf("internal-error: missing mapping implementation for %T", item)
	}

	for _, item := range input.ModelToModels {
		// NOTE: any duplications get removed below
		modelToModelMappings = append(modelToModelMappings, repositoryModels.TerraformModelToModelMappingDefinition{
			// todo remove Schema when https://github.com/hashicorp/pandora/issues/3346 is addressed
			SchemaModelName: fmt.Sprintf("%sSchema", item.TerraformSchemaModelName),
			SdkModelName:    item.SDKModelName,
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
	resourceIdMappings := mapTerraformSchemaResourceIdMappingsToRepository(input.ResourceID)
	if len(resourceIdMappings) > 0 {
		output.ResourceIdMappings = &resourceIdMappings
	}

	return &output, nil
}

func mapTerraformSchemaResourceIdMappingsToRepository(input []sdkModels.TerraformResourceIDMappingDefinition) []repositoryModels.TerraformResourceIdMappingDefinition {
	// we need the ordering to be consistent else to avoid noisy regenerations, so let's order this on one of the keys
	segmentNames := make([]string, 0)
	segmentNamesToResourceIdMappings := make(map[string]sdkModels.TerraformResourceIDMappingDefinition)
	for _, item := range input {
		segmentNames = append(segmentNames, item.SegmentName)
		segmentNamesToResourceIdMappings[item.SegmentName] = item
	}
	sort.Strings(segmentNames)

	output := make([]repositoryModels.TerraformResourceIdMappingDefinition, 0)
	for _, schemaFieldName := range segmentNames {
		resourceIdMapping := segmentNamesToResourceIdMappings[schemaFieldName]
		output = append(output, repositoryModels.TerraformResourceIdMappingDefinition{
			SchemaFieldName:    resourceIdMapping.TerraformSchemaFieldName,
			SegmentName:        resourceIdMapping.SegmentName,
			ParsedFromParentId: resourceIdMapping.ParsedFromParentID,
		})
	}
	return output
}

func orderFieldMappings(input []repositoryModels.TerraformFieldMappingDefinition) (*[]repositoryModels.TerraformFieldMappingDefinition, error) {
	keys := make([]string, 0)
	keysToValues := make(map[string]repositoryModels.TerraformFieldMappingDefinition)
	for _, item := range input {
		key := ""
		switch item.Type {
		case repositoryModels.DirectAssignmentTerraformFieldMappingDefinitionType:
			{
				key = fmt.Sprintf("%s-%s-%s-%s-%s", string(item.Type), item.DirectAssignment.SchemaModelName, item.DirectAssignment.SchemaFieldPath, item.DirectAssignment.SdkModelName, item.DirectAssignment.SdkFieldPath)
			}

		case repositoryModels.ModelToModelTerraformFieldMappingDefinitionType:
			{
				key = fmt.Sprintf("%s-%s-%s-%s", string(item.Type), item.ModelToModel.SchemaModelName, item.ModelToModel.SdkModelName, item.ModelToModel.SdkFieldName)
			}

		case repositoryModels.ManualTerraformFieldMappingDefinitionType:
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

	output := make([]repositoryModels.TerraformFieldMappingDefinition, 0)
	for _, key := range keys {
		value := keysToValues[key]
		output = append(output, value)
	}
	return &output, nil
}

func uniqueAndSortModelToModelMappings(input []repositoryModels.TerraformModelToModelMappingDefinition) []repositoryModels.TerraformModelToModelMappingDefinition {
	keysToValues := make(map[string]repositoryModels.TerraformModelToModelMappingDefinition)
	for _, item := range input {
		// using this key format means we'll also de-dupe this slice at the same time
		key := fmt.Sprintf("%s-%s", item.SchemaModelName, item.SdkModelName)
		keysToValues[key] = item
	}

	keys := make([]string, 0)
	for k := range keysToValues {
		keys = append(keys, k)
	}
	sort.Strings(keys)

	output := make([]repositoryModels.TerraformModelToModelMappingDefinition, 0)
	for _, key := range keys {
		output = append(output, keysToValues[key])
	}

	return output
}
