// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package schema

import (
	"fmt"

	sdkHelpers "github.com/hashicorp/pandora/tools/data-api-sdk/v1/helpers"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	terraformHelpers "github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/terraform/schema/helpers"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/terraform/schema/processors"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
	"github.com/hashicorp/pandora/tools/sdk/config/definitions"
)

/*
Things to do here:

1. Build the Schema
2. Ensure when we output each field we also output how to map from the model to it (we can then infer the inverse)
3. Schema Fields needs to also account for Resource ID fields too
4. Output the Schema into the Typed DSL Steve/Matthew are working on
*/

type Builder struct {
	// apiResource is the APIResource where information about the Terraform Resources can be identified from.
	apiResource sdkModels.APIResource
}

func NewBuilder(apiResource sdkModels.APIResource) Builder {
	return Builder{
		apiResource: apiResource,
	}
}

// Build produces a map of TerraformSchemaModelDefinitions which comprise the Schema for this Resource
func (b Builder) Build(input sdkModels.TerraformResourceDefinition, resourceDefinition definitions.ResourceDefinition) (map[string]sdkModels.TerraformSchemaModel, *sdkModels.TerraformMappingDefinition, error) {
	mappings := sdkModels.TerraformMappingDefinition{
		Fields:     []sdkModels.TerraformFieldMappingDefinition{},
		ResourceID: []sdkModels.TerraformResourceIDMappingDefinition{},
	}

	parsedTopLevelModel, err := b.schemaFromTopLevelModel(input, &mappings, resourceDefinition)
	if err != nil {
		return nil, nil, fmt.Errorf("building schema from top level model: %+v", err)
	}
	mappings = parsedTopLevelModel.mappings

	if parsedTopLevelModel == nil {
		// it's been filtered out, e.g. a discriminator or similar, more info in the parent error message
		logging.Tracef("top level model was filtered out")
		return nil, nil, nil
	}

	schemaModels := map[string]sdkModels.TerraformSchemaModel{
		input.SchemaModelName: parsedTopLevelModel.model,
	}

	for modelName, modelDetails := range parsedTopLevelModel.nestedModels {
		// we've already parsed this above
		if modelName == input.SchemaModelName {
			continue
		}

		// models should be prefixed with the resource name to avoid conflicts where a model is reused across a package
		// for example `VirtualMachineAdditionalCapabilitiesSchema`
		prefixedModelName := fmt.Sprintf("%s%s", input.SchemaModelName, modelName)
		nestedModelDetails, updatedMappings, err := b.buildNestedModelDefinition(prefixedModelName, input.SchemaModelName, modelName, modelDetails, input, mappings, resourceDefinition)
		if err != nil {
			return nil, nil, fmt.Errorf("building model definition for nested model %q: %+v", modelName, err)
		}
		if nestedModelDetails == nil {
			logging.Tracef("nested model %q was filtered out", modelName)
			return nil, nil, nil
		}

		schemaModels[prefixedModelName] = *nestedModelDetails
		mappings = *updatedMappings
	}

	blockHclNamesRefMap := make(map[string]string)

	// TODO: now that we have all of the models for this resource, we should loop through and check what can be cleaned up
	for modelName, model := range schemaModels {
		for _, processor := range processors.ModelRules {
			// the models within schemaModels are updated as we loop through the processors, so we need to pass in the
			// updated model from schemaModels[modelName] or previous changes are overwritten
			updatedSchemaModels, updatedMappings, err := processor.ProcessModel(modelName, schemaModels[modelName], schemaModels, mappings)
			if err != nil {
				return nil, nil, fmt.Errorf("processing models: %+v", err)
			}
			schemaModels = updatedSchemaModels
			mappings = *updatedMappings
		}

		fieldsWithHclNames := make(map[string]sdkModels.TerraformSchemaField)
		for fieldName, field := range schemaModels[modelName].Fields {
			field.HCLName = terraformHelpers.ConvertToSnakeCase(fieldName)
			fieldsWithHclNames[fieldName] = field
			objectDefinition := sdkHelpers.InnerMostTerraformSchemaObjectDefinition(field.ObjectDefinition)
			if objectDefinition.Type == sdkModels.ReferenceTerraformSchemaObjectDefinitionType {
				if objectDefinition.ReferenceName == nil {
					return nil, nil, fmt.Errorf("the Field %q within Model %q was a Reference with no ReferenceName", fieldName, modelName)
				}

				if blockRef, ok := blockHclNamesRefMap[field.HCLName]; ok {
					if blockRef != *objectDefinition.ReferenceName {
						return nil, nil, fmt.Errorf("found duplicate HCL name for block  %q: %+v", field.HCLName, err)
					}
				}
				blockHclNamesRefMap[field.HCLName] = *objectDefinition.ReferenceName
			}
		}
		model.Fields = fieldsWithHclNames
		schemaModels[modelName] = model
	}

	// finally go through and remove any unused models
	outputSchemaModels, outputMappings, err := b.removeUnusedModelsAndMappings(input, schemaModels, mappings)
	if err != nil {
		return nil, nil, fmt.Errorf("removing unused models/mappings: %+v", err)
	}

	return outputSchemaModels, outputMappings, nil
}

func (b Builder) removeUnusedModelsAndMappings(input sdkModels.TerraformResourceDefinition, schemaModels map[string]sdkModels.TerraformSchemaModel, mappings sdkModels.TerraformMappingDefinition) (map[string]sdkModels.TerraformSchemaModel, *sdkModels.TerraformMappingDefinition, error) {
	unusedModels := make(map[string]struct{}, 0)
	// first assume everything is unused
	for modelName := range schemaModels {
		unusedModels[modelName] = struct{}{}
	}

	for _, model := range schemaModels {
		for _, field := range model.Fields {
			objectDefinition := sdkHelpers.InnerMostTerraformSchemaObjectDefinition(field.ObjectDefinition)
			if objectDefinition.Type == sdkModels.ReferenceTerraformSchemaObjectDefinitionType {
				// TODO: we should check if this is a const too
				delete(unusedModels, *objectDefinition.ReferenceName)
			}
		}
	}

	delete(unusedModels, fmt.Sprintf("%sResource", input.ResourceName))

	// remove any unreferenced models
	for modelName := range unusedModels {
		delete(schemaModels, modelName)

		updatedMappings, err := removeUnusedMappingsFromSchemaModelNamed(modelName, mappings.Fields)
		if err != nil {
			return nil, nil, fmt.Errorf("removing unused schema mappings for model named %q: %+v", modelName, err)
		}
		mappings.Fields = *updatedMappings
	}

	// foreach model to model reference, if no fields within this block are being mapped, we can omit it
	// for example if no fields are mapped within the `properties` block, don't output a model-to-model mapping
	outputMappings, err := b.removeUnusedModelToModelMappings(mappings)
	if err != nil {
		return nil, nil, fmt.Errorf("removing unused ModelToModel mappings: %+v", err)
	}
	mappings = *outputMappings

	return schemaModels, &mappings, nil
}

func (b Builder) removeUnusedModelToModelMappings(input sdkModels.TerraformMappingDefinition) (*sdkModels.TerraformMappingDefinition, error) {
	output := input

	output.Fields = make([]sdkModels.TerraformFieldMappingDefinition, 0)
	for _, mapping := range input.Fields {
		v, ok := mapping.(sdkModels.TerraformModelToModelFieldMappingDefinition)
		if !ok {
			output.Fields = append(output.Fields, mapping)
			continue
		}

		sdkModel, ok := b.apiResource.Models[v.ModelToModel.SDKModelName]
		if !ok {
			return nil, fmt.Errorf("the SDK Model %q was not found", v.ModelToModel.SDKModelName)
		}
		sdkField, ok := sdkModel.Fields[v.ModelToModel.SDKFieldName]
		if !ok {
			return nil, fmt.Errorf("field %q was not found in SDK Model %q", v.ModelToModel.SDKFieldName, v.ModelToModel.SDKModelName)
		}
		objectDefinition := sdkHelpers.InnerMostSDKObjectDefinition(sdkField.ObjectDefinition)
		if objectDefinition.Type != sdkModels.ReferenceSDKObjectDefinitionType {
			// nothing to do here, move along now.
			output.Fields = append(output.Fields, mapping)
			continue
		}
		associatedModelName := *objectDefinition.ReferenceName

		hasMappings := false
		for _, other := range input.Fields {
			if o, ok := other.(sdkModels.TerraformDirectAssignmentFieldMappingDefinition); ok {
				if o.DirectAssignment.SDKModelName == associatedModelName {
					hasMappings = true
					break
				}
			}
		}
		if hasMappings {
			output.Fields = append(output.Fields, mapping)
		} else {
			logging.Tracef("removing unused ModelToModel mapping: %+v", mapping)
		}
	}

	return &output, nil
}

func removeUnusedMappingsFromSchemaModelNamed(modelName string, inputMappings []sdkModels.TerraformFieldMappingDefinition) (*[]sdkModels.TerraformFieldMappingDefinition, error) {
	output := make([]sdkModels.TerraformFieldMappingDefinition, 0)

	for _, item := range inputMappings {
		if v, ok := item.(sdkModels.TerraformDirectAssignmentFieldMappingDefinition); ok {
			if v.DirectAssignment.TerraformSchemaModelName != modelName {
				output = append(output, v)
			}
			continue
		}
		if v, ok := item.(sdkModels.TerraformModelToModelFieldMappingDefinition); ok {
			if v.ModelToModel.TerraformSchemaModelName != modelName {
				output = append(output, v)
			}
			continue
		}

		return nil, fmt.Errorf("internal-error: unimplemented mapping type %T", item)
	}

	return &output, nil
}

type modelParseResult struct {
	mappings     sdkModels.TerraformMappingDefinition
	model        sdkModels.TerraformSchemaModel
	nestedModels map[string]sdkModels.SDKModel
}

func (b Builder) schemaFromTopLevelModel(input sdkModels.TerraformResourceDefinition, mappings *sdkModels.TerraformMappingDefinition, resourceDefinition definitions.ResourceDefinition) (*modelParseResult, error) {
	createReadUpdateMethods, err := b.findCreateUpdateReadPayloads(input)
	if err != nil {
		return nil, fmt.Errorf("finding create/update/read payloads: %+v", err)
	}
	if createReadUpdateMethods == nil {
		return nil, nil
	}

	// TODO process top level fields at the end?
	// find each of the "common" top level fields, excluding `properties`
	fields, mappings, err := b.schemaFromTopLevelFields(input.SchemaModelName, *createReadUpdateMethods, mappings, input.DisplayName)
	if err != nil {
		return nil, fmt.Errorf("parsing top-level fields from create/read/update: %+v", err)
	}

	resourceId, ok := b.apiResource.ResourceIDs[input.ResourceIDName]
	if !ok {
		return nil, fmt.Errorf("couldn't find Resource ID named %q", input.ResourceIDName)
	}
	fieldsWithinResourceId, mappings, err := b.identifyTopLevelFieldsWithinResourceID(resourceId, mappings, input.DisplayName, resourceDefinition)
	if err != nil {
		displayValueForResourceId := sdkHelpers.DisplayValueForResourceID(resourceId)
		return nil, fmt.Errorf("identifying top level fields within Resource ID %q: %+v", displayValueForResourceId, err)
	}
	for k, v := range fieldsWithinResourceId {
		fields[k] = v
	}

	fieldsWithinProperties, mappings, err := b.identifyFieldsWithinPropertiesBlock(input.SchemaModelName, *createReadUpdateMethods, &input, mappings, resourceDefinition)
	if err != nil {
		return nil, fmt.Errorf("parsing fields within the `properties` block for the create/read/update methods: %+v", err)
	}
	for k, v := range fieldsWithinProperties {
		fields[k] = v
	}

	modelsUsedWithinProperties, mappings, err := b.identifyModelsWithinPropertiesBlock(*createReadUpdateMethods, mappings)
	if err != nil {
		return nil, fmt.Errorf("identifying models used within the `properties` block for the create/read/update methods: %+v", err)
	}
	if modelsUsedWithinProperties == nil {
		logging.Tracef("a model within the properties block was marked as skip - skipping")
		return nil, nil
	}

	return &modelParseResult{
		mappings: *mappings,
		model: sdkModels.TerraformSchemaModel{
			Fields: fields,
		},
		nestedModels: modelsUsedWithinProperties,
	}, nil
}

func (b Builder) identifyModelsWithinPropertiesBlock(payloads operationPayloads, mappings *sdkModels.TerraformMappingDefinition) (map[string]sdkModels.SDKModel, *sdkModels.TerraformMappingDefinition, error) {
	allFields := make(map[string]sdkModels.SDKField)
	for fieldName, field := range payloads.readPayload.Fields {
		if _, ok := allFields[fieldName]; ok {
			continue
		}

		if fieldShouldBeIgnored(fieldName, field, b.apiResource.Constants) {
			continue
		}

		allFields[fieldName] = field
	}

	allModels := make(map[string]sdkModels.SDKModel, 0)
	for fieldName, field := range allFields {
		// find models within field
		modelsWithinField, err := b.identifyModelsWithinField(field, allModels)
		if err != nil {
			return nil, nil, fmt.Errorf("identifying models within field %q: %+v", fieldName, err)
		}
		if modelsWithinField == nil {
			logging.Tracef("field %q was marked as ignored (due to discriminated types or similar) - skipping", fieldName)
			return nil, nil, nil
		}

		for k, v := range modelsWithinField {
			if other, ok := allModels[k]; ok {
				if !modelsMatch(v, other) {
					return nil, nil, fmt.Errorf("duplicate models named %q were parsed with different fields: %+v / %+v", k, v.Fields, other.Fields)
				}
			}

			allModels[k] = v
		}
	}

	return allModels, mappings, nil
}

func modelsMatch(first sdkModels.SDKModel, second sdkModels.SDKModel) bool {
	// TODO: implement me
	return len(first.Fields) == len(second.Fields)
}

func (b Builder) findCreateUpdateReadPayloads(input sdkModels.TerraformResourceDefinition) (*operationPayloads, error) {
	out := operationPayloads{}

	// Create has to exist
	createOperation, ok := b.apiResource.Operations[input.CreateMethod.SDKOperationName]
	if !ok {
		return nil, nil
	}
	if createOperation.RequestObject == nil || createOperation.RequestObject.Type != sdkModels.ReferenceSDKObjectDefinitionType || createOperation.RequestObject.ReferenceName == nil {
		// we don't generate resources for operations returning lists etc, debatable if we should
		return nil, nil
	}
	createModel, ok := b.apiResource.Models[*createOperation.RequestObject.ReferenceName]
	if !ok {
		return nil, nil
	}
	out.createModelName = *createOperation.RequestObject.ReferenceName
	out.createPayload = createModel
	createPropsModelName, createPropsModel := out.getPropertiesModelWithinModel(out.createPayload, b.apiResource.Models)
	if createPropsModelName != nil || createPropsModel != nil {
		out.createPropertiesPayload = *createPropsModel
		out.createPropertiesModelName = *createPropsModelName
	}

	// Read has to exist
	readOperation, ok := b.apiResource.Operations[input.ReadMethod.SDKOperationName]
	if !ok {
		return nil, nil
	}
	if readOperation.ResponseObject == nil || readOperation.ResponseObject.Type != sdkModels.ReferenceSDKObjectDefinitionType || readOperation.ResponseObject.ReferenceName == nil {
		// we don't generate resources for operations returning lists etc, debatable if we should
		return nil, nil
	}
	readModel, ok := b.apiResource.Models[*readOperation.ResponseObject.ReferenceName]
	if !ok {
		return nil, nil
	}
	out.readModelName = *readOperation.ResponseObject.ReferenceName
	out.readPayload = readModel
	// then find the `Properties` model within this
	readPropsModelName, readPropsModel := out.getPropertiesModelWithinModel(out.readPayload, b.apiResource.Models)
	if readPropsModelName != nil || readPropsModel != nil {
		out.readPropertiesModelName = *readPropsModelName
		out.readPropertiesPayload = *readPropsModel
	}

	// Update doesn't have to exist
	if updateMethod := input.UpdateMethod; updateMethod != nil {
		updateOperation, ok := b.apiResource.Operations[updateMethod.SDKOperationName]
		if !ok {
			return nil, nil
		}
		if updateOperation.RequestObject == nil || updateOperation.RequestObject.Type != sdkModels.ReferenceSDKObjectDefinitionType || updateOperation.RequestObject.ReferenceName == nil {
			// we don't generate resources for operations returning lists etc, debatable if we should
			return nil, nil
		}
		updateModel, ok := b.apiResource.Models[*updateOperation.RequestObject.ReferenceName]
		if !ok {
			return nil, nil
		}
		out.updateModelName = updateOperation.RequestObject.ReferenceName
		out.updatePayload = &updateModel

		// then find the `Properties` model within this
		updatePropsModelName, updatePropsModel := out.getPropertiesModelWithinModel(*out.updatePayload, b.apiResource.Models)
		if updatePropsModelName != nil || updatePropsModel != nil {
			out.updatePropertiesModelName = updatePropsModelName
			out.updatePropertiesPayload = updatePropsModel
		}
	}

	// NOTE: intentionally not including Delete since the payload shouldn't be applicable to users
	return &out, nil
}

func (b Builder) buildNestedModelDefinition(schemaModelName, topLevelModelName, sdkModelName string, model sdkModels.SDKModel, details sdkModels.TerraformResourceDefinition, mappings sdkModels.TerraformMappingDefinition, resourceDefinition definitions.ResourceDefinition) (*sdkModels.TerraformSchemaModel, *sdkModels.TerraformMappingDefinition, error) {
	out := make(map[string]sdkModels.TerraformSchemaField)

	for sdkFieldName, sdkField := range model.Fields {
		logging.Tracef("Processing Field %q", sdkFieldName)
		if objectDefinitionShouldBeSkipped(sdkField.ObjectDefinition.Type) {
			logging.Tracef("Field %q's Object Definition should be filtered out, skipping", sdkFieldName)
			continue
		}

		isComputed := !sdkField.Required && !sdkField.Optional
		isForceNew := false // TODO: implement ForceNew, which can be determined from the
		isRequired := sdkField.Required
		isOptional := sdkField.Optional

		definition := sdkModels.TerraformSchemaField{
			Required: isRequired,
			ForceNew: isForceNew,
			Optional: isOptional,
			Computed: isComputed,
		}

		fieldObjectDefinition, err := b.convertToFieldObjectDefinition(topLevelModelName, sdkField.ObjectDefinition)
		if err != nil {
			return nil, nil, fmt.Errorf("converting ObjectDefinition for field to a TerraformFieldObjectDefinition: %+v", err)
		}
		definition.ObjectDefinition = *fieldObjectDefinition
		schemaFieldName, err := updateFieldName(sdkFieldName, &model, &details, b.apiResource.Constants, resourceDefinition)
		if err != nil {
			return nil, nil, err
		}

		validation, err := getFieldValidation(sdkField, b.apiResource.Constants)
		if err != nil {
			return nil, nil, err
		}
		definition.Validation = validation
		out[schemaFieldName] = definition

		mappings.Fields = append(mappings.Fields, directAssignmentMappingBetween(schemaModelName, schemaFieldName, sdkModelName, sdkFieldName))
	}

	return &sdkModels.TerraformSchemaModel{
		Fields: out,
	}, &mappings, nil
}

func (b Builder) identifyModelsWithinField(field sdkModels.SDKField, knownModels map[string]sdkModels.SDKModel) (map[string]sdkModels.SDKModel, error) {
	out := make(map[string]sdkModels.SDKModel, 0)

	objectDefinition := sdkHelpers.InnerMostSDKObjectDefinition(field.ObjectDefinition)
	if objectDefinition.ReferenceName != nil {
		// we need to identify both this model and any models nested within it
		allModels := make(map[string]sdkModels.SDKModel)
		for k, v := range knownModels {
			allModels[k] = v
		}

		_, isConstant := b.apiResource.Constants[*objectDefinition.ReferenceName]
		model, isModel := b.apiResource.Models[*objectDefinition.ReferenceName]
		if !isConstant && !isModel {
			return nil, fmt.Errorf("reference %q was neither a constant or a model", *objectDefinition.ReferenceName)
		}

		if isModel {
			if isConstant {
				return nil, fmt.Errorf("reference %q was both a constant and a model", *objectDefinition.ReferenceName)
			}

			if model.FieldNameContainingDiscriminatedValue != nil || model.DiscriminatedValue != nil || model.ParentTypeName != nil {
				logging.Tracef("model %q was a discriminated type - skipping", *objectDefinition.ReferenceName)
				return nil, nil
			}

			out[*objectDefinition.ReferenceName] = model
			allModels[*objectDefinition.ReferenceName] = model

			// finally check if it has any models and add to that
			logging.Tracef("checking for models within fields for model %q", *objectDefinition.ReferenceName)
			for nestedFieldName, nestedField := range model.Fields {
				logging.Tracef(fmt.Sprintf("field %q", nestedFieldName))
				nestedModels, err := b.identifyModelsWithinField(nestedField, allModels)
				if err != nil {
					return nil, fmt.Errorf("identifying models within field %q: %+v", nestedFieldName, err)
				}
				if nestedModels == nil {
					// something within it was marked as ignore
					return nil, nil
				}
				for k, v := range nestedModels {
					out[k] = v
					allModels[k] = v
				}
			}
		}
	}

	return out, nil
}

func objectDefinitionShouldBeSkipped(input sdkModels.SDKObjectDefinitionType) bool {
	toSkip := map[sdkModels.SDKObjectDefinitionType]struct{}{
		sdkModels.RawFileSDKObjectDefinitionType:    {},
		sdkModels.RawObjectSDKObjectDefinitionType:  {},
		sdkModels.SystemDataSDKObjectDefinitionType: {},
	}
	_, ok := toSkip[input]
	return ok
}
