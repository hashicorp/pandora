package schema

import (
	"fmt"
	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/helpers"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/schema/processors"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

/*
Things to do here:

1. Build the Schema
2. Ensure when we output each field we also output how to map from the model to it (we can then infer the inverse)
3. Schema Fields needs to also account for Resource ID fields too
4. Output the Schema into the Typed DSL Steve/Matthew are working on
*/

type Builder struct {
	constants   map[string]resourcemanager.ConstantDetails
	models      map[string]resourcemanager.ModelDetails
	operations  map[string]resourcemanager.ApiOperation
	resourceIds map[string]resourcemanager.ResourceIdDefinition
}

func NewBuilder(constants map[string]resourcemanager.ConstantDetails, models map[string]resourcemanager.ModelDetails, operations map[string]resourcemanager.ApiOperation, resourceIds map[string]resourcemanager.ResourceIdDefinition) Builder {
	return Builder{
		constants:   constants,
		models:      models,
		operations:  operations,
		resourceIds: resourceIds,
	}
}

// Build produces a map of TerraformSchemaModelDefinitions which comprise the Schema for this Resource
func (b Builder) Build(input resourcemanager.TerraformResourceDetails, resourceBuildInfo *models.ResourceBuildInfo, logger hclog.Logger) (*map[string]resourcemanager.TerraformSchemaModelDefinition, *resourcemanager.MappingDefinition, error) {
	mappings := resourcemanager.MappingDefinition{
		Fields:     []resourcemanager.FieldMappingDefinition{},
		ResourceId: []resourcemanager.ResourceIdMappingDefinition{},
	}

	parsedTopLevelModel, err := b.schemaFromTopLevelModel(input, &mappings, resourceBuildInfo, logger.Named("top level model"))
	if err != nil {
		return nil, nil, fmt.Errorf("building schema from top level model: %+v", err)
	}
	mappings = parsedTopLevelModel.mappings

	if parsedTopLevelModel == nil {
		// it's been filtered out, e.g. a discriminator or similar, more info in the parent error message
		logger.Trace("top level model was filtered out")
		return nil, nil, nil
	}

	schemaModels := map[string]resourcemanager.TerraformSchemaModelDefinition{
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
		nestedModelDetails, updatedMappings, err := b.buildNestedModelDefinition(prefixedModelName, input.SchemaModelName, modelName, modelDetails, input, mappings, resourceBuildInfo, logger.Named(fmt.Sprintf("Nested Model Definition %q", modelName)))
		if err != nil {
			return nil, nil, fmt.Errorf("building model definition for nested model %q: %+v", modelName, err)
		}
		if nestedModelDetails == nil {
			logger.Trace(fmt.Sprintf("nested model %q was filtered out", modelName))
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
			schemaModels = *updatedSchemaModels
			mappings = *updatedMappings
		}

		fieldsWithHclNames := make(map[string]resourcemanager.TerraformSchemaFieldDefinition, 0)
		for fieldName, field := range schemaModels[modelName].Fields {
			field.HclName = helpers.ConvertToSnakeCase(fieldName)
			fieldsWithHclNames[fieldName] = field
			objectDefinition := topLevelFieldObjectDefinition(field.ObjectDefinition)
			if objectDefinition.Type == resourcemanager.TerraformSchemaFieldTypeReference {
				if objectDefinition.ReferenceName == nil {
					return nil, nil, fmt.Errorf("the Field %q within Model %q was a Reference with no ReferenceName", fieldName, modelName)
				}

				if blockRef, ok := blockHclNamesRefMap[field.HclName]; ok {
					if blockRef != *objectDefinition.ReferenceName {
						return nil, nil, fmt.Errorf("found duplicate HCL name for block  %q: %+v", field.HclName, err)
					}
				}
				blockHclNamesRefMap[field.HclName] = *objectDefinition.ReferenceName
			}
		}
		model.Fields = fieldsWithHclNames
		schemaModels[modelName] = model
	}

	// finally go through and remove any unused models
	outputSchemaModels, outputMappings, err := b.removeUnusedModelsAndMappings(input, schemaModels, mappings, logger.Named("Cleanup unused Models and Mappings"))
	if err != nil {
		return nil, nil, fmt.Errorf("removing unused models/mappings: %+v", err)
	}

	return outputSchemaModels, outputMappings, nil
}

func (b Builder) removeUnusedModelsAndMappings(input resourcemanager.TerraformResourceDetails, models map[string]resourcemanager.TerraformSchemaModelDefinition, mappings resourcemanager.MappingDefinition, logger hclog.Logger) (*map[string]resourcemanager.TerraformSchemaModelDefinition, *resourcemanager.MappingDefinition, error) {
	unusedModels := make(map[string]struct{}, 0)
	// first assume everything is unused
	for modelName := range models {
		unusedModels[modelName] = struct{}{}
	}

	for _, model := range models {
		for _, field := range model.Fields {
			objectDefinition := topLevelFieldObjectDefinition(field.ObjectDefinition)
			if objectDefinition.Type == resourcemanager.TerraformSchemaFieldTypeReference {
				// TODO: we should check if this is a const too
				delete(unusedModels, *objectDefinition.ReferenceName)
			}
		}
	}

	delete(unusedModels, fmt.Sprintf("%sResource", input.ResourceName))

	// remove any unreferenced models
	for modelName := range unusedModels {
		delete(models, modelName)

		updatedMappings, err := removeUnusedMappingsFromSchemaModelNamed(modelName, mappings.Fields)
		if err != nil {
			return nil, nil, fmt.Errorf("removing unused schema mappings for model named %q: %+v", modelName, err)
		}
		mappings.Fields = *updatedMappings
	}

	// foreach model to model reference, if no fields within this block are being mapped, we can omit it
	// for example if no fields are mapped within the `properties` block, don't output a model-to-model mapping
	outputMappings, err := b.removeUnusedModelToModelMappings(mappings, logger)
	if err != nil {
		return nil, nil, fmt.Errorf("removing unused ModelToModel mappings: %+v", err)
	}
	mappings = *outputMappings

	return &models, &mappings, nil
}

func (b Builder) removeUnusedModelToModelMappings(input resourcemanager.MappingDefinition, logger hclog.Logger) (*resourcemanager.MappingDefinition, error) {
	output := input

	output.Fields = make([]resourcemanager.FieldMappingDefinition, 0)
	for _, mapping := range input.Fields {
		if mapping.Type != resourcemanager.ModelToModelMappingDefinitionType {
			output.Fields = append(output.Fields, mapping)
			continue
		}

		sdkModel, ok := b.models[mapping.ModelToModel.SdkModelName]
		if !ok {
			return nil, fmt.Errorf("the SDK Model %q was not found", mapping.ModelToModel.SdkModelName)
		}
		sdkField, ok := sdkModel.Fields[mapping.ModelToModel.SdkFieldName]
		if !ok {
			return nil, fmt.Errorf("field %q was not found in SDK Model %q", mapping.ModelToModel.SdkFieldName, mapping.ModelToModel.SdkModelName)
		}
		objectDefinition := topLevelObjectDefinition(sdkField.ObjectDefinition)
		if objectDefinition.Type != resourcemanager.ReferenceApiObjectDefinitionType {
			// nothing to do here, move along now.
			output.Fields = append(output.Fields, mapping)
			continue
		}
		associatedModelName := *objectDefinition.ReferenceName

		hasMappings := false
		for _, other := range input.Fields {
			if other.Type == resourcemanager.DirectAssignmentMappingDefinitionType {
				if other.DirectAssignment.SdkModelName == associatedModelName {
					hasMappings = true
					break
				}
			}
		}
		if hasMappings {
			output.Fields = append(output.Fields, mapping)
		} else {
			logger.Trace(fmt.Sprintf("removing unused ModelToModel mapping: %s", mapping.String()))
		}
	}

	return &output, nil
}

func removeUnusedMappingsFromSchemaModelNamed(modelName string, inputMappings []resourcemanager.FieldMappingDefinition) (*[]resourcemanager.FieldMappingDefinition, error) {
	output := make([]resourcemanager.FieldMappingDefinition, 0)

	for _, item := range inputMappings {
		switch item.Type {
		case resourcemanager.DirectAssignmentMappingDefinitionType:
			{
				if item.DirectAssignment.SchemaModelName != modelName {
					output = append(output, item)
				}
				continue
			}
		case resourcemanager.ModelToModelMappingDefinitionType:
			{
				if item.ModelToModel.SchemaModelName != modelName {
					output = append(output, item)
				}
				continue
			}

		default:
			{
				return nil, fmt.Errorf("internal-error: unimplemented mapping type %q", string(item.Type))
			}
		}
	}

	return &output, nil
}

type modelParseResult struct {
	mappings     resourcemanager.MappingDefinition
	model        resourcemanager.TerraformSchemaModelDefinition
	nestedModels map[string]resourcemanager.ModelDetails
}

func (b Builder) schemaFromTopLevelModel(input resourcemanager.TerraformResourceDetails, mappings *resourcemanager.MappingDefinition, resourceBuildInfo *models.ResourceBuildInfo, logger hclog.Logger) (*modelParseResult, error) {
	createReadUpdateMethods, err := b.findCreateUpdateReadPayloads(input)
	if err != nil {
		return nil, fmt.Errorf("finding create/update/read payloads: %+v", err)
	}
	if createReadUpdateMethods == nil {
		return nil, nil
	}

	// TODO process top level fields at the end?
	// find each of the "common" top level fields, excluding `properties`
	fields, mappings, err := b.schemaFromTopLevelFields(input.SchemaModelName, *createReadUpdateMethods, mappings, input.DisplayName, logger.Named("TopLevelFields"))
	if err != nil {
		return nil, fmt.Errorf("parsing top-level fields from create/read/update: %+v", err)
	}

	schemaFields := *fields

	resourceId, ok := b.resourceIds[input.ResourceIdName]
	if !ok {
		return nil, fmt.Errorf("couldn't find Resource ID named %q", input.ResourceIdName)
	}
	fieldsWithinResourceId, mappings, err := b.identifyTopLevelFieldsWithinResourceID(resourceId, mappings, input.DisplayName, resourceBuildInfo, logger.Named("TopLevelFields ResourceID"))
	if err != nil {
		return nil, fmt.Errorf("identifying top level fields within Resource ID %q: %+v", resourceId.Id, err)
	}
	for k, v := range *fieldsWithinResourceId {
		schemaFields[k] = v
	}

	fieldsWithinProperties, mappings, err := b.identifyFieldsWithinPropertiesBlock(input.SchemaModelName, *createReadUpdateMethods, &input, mappings, resourceBuildInfo, logger.Named("TopLevelFields PropertiesFields"))
	if err != nil {
		return nil, fmt.Errorf("parsing fields within the `properties` block for the create/read/update methods: %+v", err)
	}
	for k, v := range *fieldsWithinProperties {
		schemaFields[k] = v
	}

	modelsUsedWithinProperties, mappings, err := b.identifyModelsWithinPropertiesBlock(*createReadUpdateMethods, mappings, logger.Named("Models within Property Block"))
	if err != nil {
		return nil, fmt.Errorf("identifying models used within the `properties` block for the create/read/update methods: %+v", err)
	}
	if modelsUsedWithinProperties == nil {
		logger.Trace(fmt.Sprintf("a model within the properties block was marked as skip - skipping"))
		return nil, nil
	}

	// @tombuildsstuff: this is a temporary workaround to strip out the `encryption` block for the Load Test Service
	// the fix is tracked in https://github.com/hashicorp/pandora/issues/2608
	// NOTE: other resources shouldn't use this approach and should instead fix the issue blocking generation - this
	// is temporary to unblock this migration, since this has already shipped.
	if input.SchemaModelName == "LoadTestResource" {
		modelsUsedWithinProperties, mappings, err = applyTemporaryWorkaroundToLoadTestModelsAndMappings(*modelsUsedWithinProperties, mappings)
		if err != nil {
			return nil, fmt.Errorf("applying temporary workaround for Load Test: %+v", err)
		}
	}

	return &modelParseResult{
		mappings: *mappings,
		model: resourcemanager.TerraformSchemaModelDefinition{
			Fields: schemaFields,
		},
		nestedModels: *modelsUsedWithinProperties,
	}, nil
}

func (b Builder) identifyModelsWithinPropertiesBlock(payloads operationPayloads, mappings *resourcemanager.MappingDefinition, logger hclog.Logger) (*map[string]resourcemanager.ModelDetails, *resourcemanager.MappingDefinition, error) {
	allFields := make(map[string]resourcemanager.FieldDetails, 0)
	for fieldName, field := range payloads.readPayload.Fields {
		if _, ok := allFields[fieldName]; ok {
			continue
		}

		if fieldShouldBeIgnored(fieldName, field, b.constants) {
			continue
		}

		allFields[fieldName] = field
	}

	allModels := make(map[string]resourcemanager.ModelDetails, 0)
	for fieldName, field := range allFields {
		// find models within field
		modelsWithinField, err := b.identifyModelsWithinField(field, allModels, logger)
		if err != nil {
			return nil, nil, fmt.Errorf("identifying models within field %q: %+v", fieldName, err)
		}
		if modelsWithinField == nil {
			logger.Trace(fmt.Sprintf("field %q was marked as ignored (due to discriminated types or similar) - skipping", fieldName))
			return nil, nil, nil
		}

		for k, v := range *modelsWithinField {
			if other, ok := allModels[k]; ok {
				if !modelsMatch(v, other) {
					return nil, nil, fmt.Errorf("duplicate models named %q were parsed with different fields: %+v / %+v", k, v.Fields, other.Fields)
				}
			}

			allModels[k] = v
		}
	}

	return &allModels, mappings, nil
}

func modelsMatch(first resourcemanager.ModelDetails, second resourcemanager.ModelDetails) bool {
	// TODO: implement me
	return len(first.Fields) == len(second.Fields)
}

func (b Builder) findCreateUpdateReadPayloads(input resourcemanager.TerraformResourceDetails) (*operationPayloads, error) {
	out := operationPayloads{}

	// Create has to exist
	createOperation, ok := b.operations[input.CreateMethod.MethodName]
	if !ok {
		return nil, nil
	}
	if createOperation.RequestObject == nil || createOperation.RequestObject.Type != resourcemanager.ReferenceApiObjectDefinitionType || createOperation.RequestObject.ReferenceName == nil {
		// we don't generate resources for operations returning lists etc, debatable if we should
		return nil, nil
	}
	createModel, ok := b.models[*createOperation.RequestObject.ReferenceName]
	if !ok {
		return nil, nil
	}
	out.createModelName = *createOperation.RequestObject.ReferenceName
	out.createPayload = createModel
	createPropsModelName, createPropsModel := out.getPropertiesModelWithinModel(out.createPayload, b.models)
	if createPropsModelName != nil || createPropsModel != nil {
		out.createPropertiesPayload = *createPropsModel
		out.createPropertiesModelName = *createPropsModelName
	}

	// Read has to exist
	readOperation, ok := b.operations[input.ReadMethod.MethodName]
	if !ok {
		return nil, nil
	}
	if readOperation.ResponseObject == nil || readOperation.ResponseObject.Type != resourcemanager.ReferenceApiObjectDefinitionType || readOperation.ResponseObject.ReferenceName == nil {
		// we don't generate resources for operations returning lists etc, debatable if we should
		return nil, nil
	}
	readModel, ok := b.models[*readOperation.ResponseObject.ReferenceName]
	if !ok {
		return nil, nil
	}
	out.readModelName = *readOperation.ResponseObject.ReferenceName
	out.readPayload = readModel
	// then find the `Properties` model within this
	readPropsModelName, readPropsModel := out.getPropertiesModelWithinModel(out.readPayload, b.models)
	if readPropsModelName != nil || readPropsModel != nil {
		out.readPropertiesModelName = *readPropsModelName
		out.readPropertiesPayload = *readPropsModel
	}

	// Update doesn't have to exist
	if updateMethod := input.UpdateMethod; updateMethod != nil {
		updateOperation, ok := b.operations[updateMethod.MethodName]
		if !ok {
			return nil, nil
		}
		if updateOperation.RequestObject == nil || updateOperation.RequestObject.Type != resourcemanager.ReferenceApiObjectDefinitionType || updateOperation.RequestObject.ReferenceName == nil {
			// we don't generate resources for operations returning lists etc, debatable if we should
			return nil, nil
		}
		updateModel, ok := b.models[*updateOperation.RequestObject.ReferenceName]
		if !ok {
			return nil, nil
		}
		out.updateModelName = updateOperation.RequestObject.ReferenceName
		out.updatePayload = &updateModel

		// then find the `Properties` model within this
		updatePropsModelName, updatePropsModel := out.getPropertiesModelWithinModel(*out.updatePayload, b.models)
		if updatePropsModelName != nil || updatePropsModel != nil {
			out.updatePropertiesModelName = updatePropsModelName
			out.updatePropertiesPayload = updatePropsModel
		}
	}

	// NOTE: intentionally not including Delete since the payload shouldn't be applicable to users
	return &out, nil
}

func (b Builder) buildNestedModelDefinition(schemaModelName, topLevelModelName, sdkModelName string, model resourcemanager.ModelDetails, details resourcemanager.TerraformResourceDetails, mappings resourcemanager.MappingDefinition, resourceBuildInfo *models.ResourceBuildInfo, logger hclog.Logger) (*resourcemanager.TerraformSchemaModelDefinition, *resourcemanager.MappingDefinition, error) {
	out := make(map[string]resourcemanager.TerraformSchemaFieldDefinition, 0)

	for sdkFieldName, sdkField := range model.Fields {
		logger.Trace(fmt.Sprintf("Processing Field %q", sdkFieldName))
		if objectDefinitionShouldBeSkipped(sdkField.ObjectDefinition.Type) {
			logger.Trace(fmt.Sprintf("Field %q's Object Definition should be filtered out, skipping", sdkFieldName))
			continue
		}

		isComputed := !sdkField.Required && !sdkField.Optional
		isForceNew := sdkField.ForceNew
		isRequired := sdkField.Required
		isOptional := sdkField.Optional

		definition := resourcemanager.TerraformSchemaFieldDefinition{
			Required: isRequired,
			ForceNew: isForceNew,
			Optional: isOptional,
			Computed: isComputed,
		}
		// TODO: refactor this to use the shared logic

		fieldObjectDefinition, err := b.convertToFieldObjectDefinition(topLevelModelName, sdkField.ObjectDefinition)
		if err != nil {
			return nil, nil, fmt.Errorf("converting ObjectDefinition for field to a TerraformFieldObjectDefinition: %+v", err)
		}
		definition.ObjectDefinition = *fieldObjectDefinition
		schemaFieldName, err := updateFieldName(sdkFieldName, &model, &details, b.constants, resourceBuildInfo)
		if err != nil {
			return nil, nil, err
		}

		validation, err := getFieldValidation(sdkField.Validation, schemaFieldName)
		if err != nil {
			return nil, nil, err
		}
		definition.Validation = validation
		out[schemaFieldName] = definition

		mappings.Fields = append(mappings.Fields, directAssignmentMappingBetween(schemaModelName, schemaFieldName, sdkModelName, sdkFieldName))
	}

	return &resourcemanager.TerraformSchemaModelDefinition{
		Fields: out,
	}, &mappings, nil
}

func (b Builder) identifyModelsWithinField(field resourcemanager.FieldDetails, knownModels map[string]resourcemanager.ModelDetails, logger hclog.Logger) (*map[string]resourcemanager.ModelDetails, error) {
	out := make(map[string]resourcemanager.ModelDetails, 0)

	objectDefinition := topLevelObjectDefinition(field.ObjectDefinition)
	if objectDefinition.ReferenceName != nil {
		// we need to identify both this model and any models nested within it
		allModels := make(map[string]resourcemanager.ModelDetails)
		for k, v := range knownModels {
			allModels[k] = v
		}

		_, isConstant := b.constants[*objectDefinition.ReferenceName]
		model, isModel := b.models[*objectDefinition.ReferenceName]
		if !isConstant && !isModel {
			return nil, fmt.Errorf("reference %q was neither a constant or a model", *objectDefinition.ReferenceName)
		}

		if isModel {
			if isConstant {
				return nil, fmt.Errorf("reference %q was both a constant and a model", *objectDefinition.ReferenceName)
			}

			if model.TypeHintIn != nil || model.TypeHintValue != nil || model.ParentTypeName != nil {
				logger.Trace("model %q was a discriminated type - skipping", *objectDefinition.ReferenceName)
				return nil, nil
			}

			out[*objectDefinition.ReferenceName] = model
			allModels[*objectDefinition.ReferenceName] = model

			// finally check if it has any models and add to that
			logger.Trace(fmt.Sprintf("checking for models within fields for model %q", *objectDefinition.ReferenceName))
			for nestedFieldName, nestedField := range model.Fields {
				logger.Trace(fmt.Sprintf("field %q", nestedFieldName))
				nestedModels, err := b.identifyModelsWithinField(nestedField, allModels, logger.Named(fmt.Sprintf("Model %q / Field %q", *objectDefinition.ReferenceName, nestedFieldName)))
				if err != nil {
					return nil, fmt.Errorf("identifying models within field %q: %+v", nestedFieldName, err)
				}
				if nestedModels == nil {
					// something within it was marked as ignore
					return nil, nil
				}
				for k, v := range *nestedModels {
					out[k] = v
					allModels[k] = v
				}
			}
		}
	}

	return &out, nil
}

func objectDefinitionShouldBeSkipped(input resourcemanager.ApiObjectDefinitionType) bool {
	toSkip := map[resourcemanager.ApiObjectDefinitionType]struct{}{
		resourcemanager.RawFileApiObjectDefinitionType:   {},
		resourcemanager.RawObjectApiObjectDefinitionType: {},
		resourcemanager.SystemData:                       {},
	}
	_, ok := toSkip[input]
	return ok
}

func topLevelObjectDefinition(input resourcemanager.ApiObjectDefinition) resourcemanager.ApiObjectDefinition {
	if input.NestedItem != nil {
		return topLevelObjectDefinition(*input.NestedItem)
	}

	return input
}

func topLevelFieldObjectDefinition(input resourcemanager.TerraformSchemaFieldObjectDefinition) resourcemanager.TerraformSchemaFieldObjectDefinition {
	if input.NestedObject != nil {
		return topLevelFieldObjectDefinition(*input.NestedObject)
	}

	return input
}
