// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"
	"sort"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/sdk/dataapimodels"
)

func MapTerraformSchemaMappingsToRepository(input models.TerraformMappingDefinition) (*dataapimodels.TerraformMappingDefinition, error) {
	output := dataapimodels.TerraformMappingDefinition{}

	fieldMappings := make([]dataapimodels.TerraformFieldMappingDefinition, 0)
	modelToModelMappings := make([]dataapimodels.TerraformModelToModelMappingDefinition, 0)
	for _, item := range input.Fields {
		if v, ok := item.(models.TerraformDirectAssignmentFieldMappingDefinition); ok {
			// DirectAssignment Mappings come solely from the Mapping themselves
			fieldMappings = append(fieldMappings, dataapimodels.TerraformFieldMappingDefinition{
				Type: dataapimodels.DirectAssignmentTerraformFieldMappingDefinitionType,
				DirectAssignment: &dataapimodels.TerraformFieldMappingDirectAssignmentDefinition{
					// todo remove Schema when https://github.com/hashicorp/pandora/issues/3346 is addressed
					SchemaModelName: fmt.Sprintf("%sSchema", v.DirectAssignment.TerraformSchemaModelName),
					SchemaFieldPath: v.DirectAssignment.TerraformSchemaFieldName,
					SdkModelName:    v.DirectAssignment.SDKModelName,
					SdkFieldPath:    v.DirectAssignment.SDKFieldName,
				},
			})
			// NOTE: any duplications get removed below - so this is safe for now
			modelToModelMappings = append(modelToModelMappings, dataapimodels.TerraformModelToModelMappingDefinition{
				// todo remove Schema when https://github.com/hashicorp/pandora/issues/3346 is addressed
				SchemaModelName: fmt.Sprintf("%sSchema", v.DirectAssignment.TerraformSchemaModelName),
				SdkModelName:    v.DirectAssignment.SDKModelName,
			})
			continue
		}

		if v, ok := item.(models.TerraformModelToModelFieldMappingDefinition); ok {
			// ModelToModel mappings need to be output both for Fields and for the Models themselves
			// this is because a ModelToModel mapping must exist from the Schema Model to the SDK Model
			// but also from a given Schema Field to a given SDK Model.
			//
			// This allows both the mapping function between two models to be generated (the `ModelToModelMappings`)
			// and the mapping between a given Schema Field and an SDK Model (so that we know to call the
			// mapping function defined in the `ModelToModelMappings`).
			fieldMappings = append(fieldMappings, dataapimodels.TerraformFieldMappingDefinition{
				Type: dataapimodels.ModelToModelTerraformFieldMappingDefinitionType,
				ModelToModel: &dataapimodels.TerraformFieldMappingModelToModelDefinition{
					// todo remove Schema when https://github.com/hashicorp/pandora/issues/3346 is addressed
					SchemaModelName: fmt.Sprintf("%sSchema", v.ModelToModel.TerraformSchemaModelName),
					SdkModelName:    v.ModelToModel.SDKModelName,
					SdkFieldName:    v.ModelToModel.SDKFieldName,
				},
			})
			// NOTE: any duplications get removed below - so this is safe for now
			modelToModelMappings = append(modelToModelMappings, dataapimodels.TerraformModelToModelMappingDefinition{
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
		modelToModelMappings = append(modelToModelMappings, dataapimodels.TerraformModelToModelMappingDefinition{
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

func mapTerraformSchemaResourceIdMappingsToRepository(input []models.TerraformResourceIDMappingDefinition) []dataapimodels.TerraformResourceIdMappingDefinition {
	// we need the ordering to be consistent else to avoid noisy regenerations, so let's order this on one of the keys
	segmentNames := make([]string, 0)
	segmentNamesToResourceIdMappings := make(map[string]models.TerraformResourceIDMappingDefinition)
	for _, item := range input {
		segmentNames = append(segmentNames, item.SegmentName)
		segmentNamesToResourceIdMappings[item.SegmentName] = item
	}
	sort.Strings(segmentNames)

	output := make([]dataapimodels.TerraformResourceIdMappingDefinition, 0)
	for _, schemaFieldName := range segmentNames {
		resourceIdMapping := segmentNamesToResourceIdMappings[schemaFieldName]
		output = append(output, dataapimodels.TerraformResourceIdMappingDefinition{
			SchemaFieldName:    resourceIdMapping.TerraformSchemaFieldName,
			SegmentName:        resourceIdMapping.SegmentName,
			ParsedFromParentId: resourceIdMapping.ParsedFromParentID,
		})
	}
	return output
}

func orderFieldMappings(input []dataapimodels.TerraformFieldMappingDefinition) (*[]dataapimodels.TerraformFieldMappingDefinition, error) {
	keys := make([]string, 0)
	keysToValues := make(map[string]dataapimodels.TerraformFieldMappingDefinition)
	for _, item := range input {
		key := ""
		switch item.Type {
		case dataapimodels.DirectAssignmentTerraformFieldMappingDefinitionType:
			{
				key = fmt.Sprintf("%s-%s-%s-%s-%s", string(item.Type), item.DirectAssignment.SchemaModelName, item.DirectAssignment.SchemaFieldPath, item.DirectAssignment.SdkModelName, item.DirectAssignment.SdkFieldPath)
			}

		case dataapimodels.ModelToModelTerraformFieldMappingDefinitionType:
			{
				key = fmt.Sprintf("%s-%s-%s-%s", string(item.Type), item.ModelToModel.SchemaModelName, item.ModelToModel.SdkModelName, item.ModelToModel.SdkFieldName)
			}

		case dataapimodels.ManualTerraformFieldMappingDefinitionType:
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

	output := make([]dataapimodels.TerraformFieldMappingDefinition, 0)
	for _, key := range keys {
		value := keysToValues[key]
		output = append(output, value)
	}
	return &output, nil
}

func uniqueAndSortModelToModelMappings(input []dataapimodels.TerraformModelToModelMappingDefinition) []dataapimodels.TerraformModelToModelMappingDefinition {
	keysToValues := make(map[string]dataapimodels.TerraformModelToModelMappingDefinition)
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

	output := make([]dataapimodels.TerraformModelToModelMappingDefinition, 0)
	for _, key := range keys {
		output = append(output, keysToValues[key])
	}

	return output
}
