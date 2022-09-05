package schema

import (
	"fmt"

	"github.com/hashicorp/go-hclog"
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
	Constants   map[string]resourcemanager.ConstantDetails
	Models      map[string]resourcemanager.ModelDetails
	Operations  map[string]resourcemanager.ApiOperation
	ResourceIds map[string]resourcemanager.ResourceIdDefinition
}

func NewBuilder(Constants map[string]resourcemanager.ConstantDetails, Models map[string]resourcemanager.ModelDetails, Operations map[string]resourcemanager.ApiOperation, ResourceIds map[string]resourcemanager.ResourceIdDefinition) Builder {
	return Builder{
		Constants:   Constants,
		Models:      Models,
		Operations:  Operations,
		ResourceIds: ResourceIds,
	}
}

// Build produces a map of TerraformSchemaModelDefinitions which comprise the Schema for this Resource
func (b Builder) Build(input resourcemanager.TerraformResourceDetails, logger hclog.Logger) (*map[string]resourcemanager.TerraformSchemaModelDefinition, error) {
	// TODO: we also need mappings

	parsedTopLevelModel, err := b.schemaFromTopLevelModel(input, logger.Named("top level model"))
	if err != nil {
		return nil, fmt.Errorf("building schema from top level model: %+v", err)
	}

	if parsedTopLevelModel == nil {
		// it's been filtered out, e.g. a discriminator or similar, more info in the parent error message
		logger.Trace("top level model was filtered out")
		return nil, nil
	}

	schemaModels := map[string]resourcemanager.TerraformSchemaModelDefinition{
		input.SchemaModelName: parsedTopLevelModel.model,
	}

	for modelName, modelDetails := range parsedTopLevelModel.nestedModels {
		// we've already parsed this above
		if modelName == input.SchemaModelName {
			continue
		}

		// Models should be prefixed with the resource name to avoid conflicts where a model is reused across a package
		// for example `VirtualMachineAdditionalCapabilitiesSchema`
		nestedModelDetails, err := b.buildNestedModelDefinition(input.SchemaModelName, modelDetails, input, logger.Named(fmt.Sprintf("Nested Model Definition %q", modelName)))
		if err != nil {
			return nil, fmt.Errorf("building model definition for nested model %q: %+v", modelName, err)
		}
		if nestedModelDetails == nil {
			logger.Trace(fmt.Sprintf("nested model %q was filtered out", modelName))
			return nil, nil
		}

		prefixedModelName := fmt.Sprintf("%s%s", input.SchemaModelName, modelName)
		schemaModels[prefixedModelName] = *nestedModelDetails
	}

	// TODO: now that we have all of the Models for this resource, we should loop through and check what can be cleaned up

	return &schemaModels, nil
}

type modelParseResult struct {
	model        resourcemanager.TerraformSchemaModelDefinition
	nestedModels map[string]resourcemanager.ModelDetails
}

func (b Builder) schemaFromTopLevelModel(input resourcemanager.TerraformResourceDetails, logger hclog.Logger) (*modelParseResult, error) {
	createReadUpdateMethods := b.findCreateUpdateReadPayloads(input)
	if createReadUpdateMethods == nil {
		return nil, nil
	}

	// find each of the "common" top level fields, excluding `properties`
	topLevelFields, err := b.identifyTopLevelFields(input.SchemaModelName, *createReadUpdateMethods)
	if err != nil {
		return nil, fmt.Errorf("parsing top-level fields from create/read/update: %+v", err)
	}

	schemaFields := make(map[string]resourcemanager.TerraformSchemaFieldDefinition)
	for k, v := range topLevelFields.toSchema() {
		schemaFields[k] = v
	}

	resourceId, ok := b.ResourceIds[input.ResourceIdName]
	if !ok {
		return nil, fmt.Errorf("couldn't find Resource ID named %q", input.ResourceIdName)
	}
	fieldsWithinResourceId, err := b.identityTopLevelFieldsWithinResourceID(resourceId)
	if err != nil {
		return nil, fmt.Errorf("identifying top level fields within Resource ID %q: %+v", resourceId.Id, err)
	}
	for k, v := range *fieldsWithinResourceId {
		schemaFields[k] = v
	}

	fieldsWithinProperties, err := b.identifyFieldsWithinPropertiesBlock(input.SchemaModelName, *createReadUpdateMethods, &input)
	if err != nil {
		return nil, fmt.Errorf("parsing fields within the `properties` block for the create/read/update methods: %+v", err)
	}
	for k, v := range *fieldsWithinProperties {
		schemaFields[k] = v
	}
	//  field renaming happens here?

	ModelsUsedWithinProperties, err := b.identifyModelsWithinPropertiesBlock(*createReadUpdateMethods, logger.Named("Models within Property Block"))
	if err != nil {
		return nil, fmt.Errorf("identifying Models used within the `properties` block for the create/read/update methods: %+v", err)
	}
	if ModelsUsedWithinProperties == nil {
		logger.Trace(fmt.Sprintf("a model within the properties block was marked as skip - skipping"))
		return nil, nil
	}

	return &modelParseResult{
		model: resourcemanager.TerraformSchemaModelDefinition{
			Fields: schemaFields,
		},
		nestedModels: *ModelsUsedWithinProperties,
	}, nil
}

func (b Builder) identifyModelsWithinPropertiesBlock(payloads operationPayloads, logger hclog.Logger) (*map[string]resourcemanager.ModelDetails, error) {
	allFields := make(map[string]resourcemanager.FieldDetails, 0)
	for fieldName, field := range payloads.readPayload.Fields {
		if _, ok := allFields[fieldName]; ok {
			continue
		}
		if fieldShouldBeIgnored(fieldName, field, b.Constants) {
			continue
		}

		allFields[fieldName] = field
	}

	allModels := make(map[string]resourcemanager.ModelDetails, 0)
	for fieldName, field := range allFields {
		// find Models within field
		ModelsWithinField, err := b.identifyModelsWithinField(field, allModels, logger)
		if err != nil {
			return nil, fmt.Errorf("identifying Models within field %q: %+v", fieldName, err)
		}
		if ModelsWithinField == nil {
			logger.Trace(fmt.Sprintf("field %q was marked as ignored (due to discriminated types or similar) - skipping", fieldName))
			return nil, nil
		}

		for k, v := range *ModelsWithinField {
			if other, ok := allModels[k]; ok {
				if !ModelsMatch(v, other) {
					return nil, fmt.Errorf("duplicate Models named %q were parsed with different fields: %+v / %+v", k, v.Fields, other.Fields)
				}
			}

			allModels[k] = v
		}
	}

	return &allModels, nil
}

func ModelsMatch(first resourcemanager.ModelDetails, second resourcemanager.ModelDetails) bool {
	// TODO: implement me
	return len(first.Fields) == len(second.Fields)
}

func (b Builder) buildNestedModelDefinition(modelPrefix string, model resourcemanager.ModelDetails, details resourcemanager.TerraformResourceDetails, logger hclog.Logger) (*resourcemanager.TerraformSchemaModelDefinition, error) {
	out := make(map[string]resourcemanager.TerraformSchemaFieldDefinition, 0)

	for k, v := range model.Fields {
		if objectDefinitionShouldBeSkipped(v.ObjectDefinition.Type) {
			continue
		}

		isComputed := false // Can we work this out yet?
		isForceNew := v.ForceNew
		isRequired := v.Required
		isOptional := v.Optional

		definition := resourcemanager.TerraformSchemaFieldDefinition{
			Required: isRequired,
			ForceNew: isForceNew,
			Optional: isOptional,
			Computed: isComputed,
		}
		// TODO: refactor this to use the shared logic

		fieldObjectDefinition, err := b.convertToFieldObjectDefinition(modelPrefix, v.ObjectDefinition)
		if err != nil {
			return nil, fmt.Errorf("converting ObjectDefinition for field to a TerraformFieldObjectDefinition: %+v", err)
		}
		definition.ObjectDefinition = *fieldObjectDefinition
		fieldName := updateFieldName(k, b, &model, &details)
		definition.HclName = convertToSnakeCase(fieldName)
		out[fieldName] = definition
	}

	return &resourcemanager.TerraformSchemaModelDefinition{
		Fields: out,
	}, nil
}

func (b Builder) findCreateUpdateReadPayloads(input resourcemanager.TerraformResourceDetails) *operationPayloads {
	out := operationPayloads{}

	// Create has to exist
	createOperation, ok := b.Operations[input.CreateMethod.MethodName]
	if !ok {
		return nil
	}
	if createOperation.RequestObject == nil || createOperation.RequestObject.Type != resourcemanager.ReferenceApiObjectDefinitionType || createOperation.RequestObject.ReferenceName == nil {
		// we don't generate resources for Operations returning lists etc, debatable if we should
		return nil
	}
	createModel, ok := b.Models[*createOperation.RequestObject.ReferenceName]
	if !ok {
		return nil
	}
	out.createPayload = createModel

	// Read has to exist
	readOperation, ok := b.Operations[input.ReadMethod.MethodName]
	if !ok {
		return nil
	}
	if readOperation.ResponseObject == nil || readOperation.ResponseObject.Type != resourcemanager.ReferenceApiObjectDefinitionType || readOperation.ResponseObject.ReferenceName == nil {
		// we don't generate resources for Operations returning lists etc, debatable if we should
		return nil
	}
	readModel, ok := b.Models[*readOperation.ResponseObject.ReferenceName]
	if !ok {
		return nil
	}
	out.readPayload = readModel

	// Update doesn't have to exist
	if updateMethod := input.UpdateMethod; updateMethod != nil {
		updateOperation, ok := b.Operations[updateMethod.MethodName]
		if !ok {
			return nil
		}
		if updateOperation.RequestObject == nil || updateOperation.RequestObject.Type != resourcemanager.ReferenceApiObjectDefinitionType || updateOperation.RequestObject.ReferenceName == nil {
			// we don't generate resources for Operations returning lists etc, debatable if we should
			return nil
		}
		updateModel, ok := b.Models[*updateOperation.RequestObject.ReferenceName]
		if !ok {
			return nil
		}
		out.updatePayload = &updateModel
	}
	// NOTE: intentionally not including Delete since the payload shouldn't be applicable to users
	return &out
}

func (b Builder) identifyModelsWithinField(field resourcemanager.FieldDetails, knownModels map[string]resourcemanager.ModelDetails, logger hclog.Logger) (*map[string]resourcemanager.ModelDetails, error) {
	out := make(map[string]resourcemanager.ModelDetails, 0)

	objectDefinition := topLevelObjectDefinition(field.ObjectDefinition)
	if objectDefinition.ReferenceName != nil {
		// we need to identify both this model and any Models nested within it
		allModels := make(map[string]resourcemanager.ModelDetails)
		for k, v := range knownModels {
			allModels[k] = v
		}

		_, isConstant := b.Constants[*objectDefinition.ReferenceName]
		model, isModel := b.Models[*objectDefinition.ReferenceName]
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

			// finally check if it has any Models and add to that
			logger.Trace(fmt.Sprintf("checking for Models within fields for model %q", *objectDefinition.ReferenceName))
			for nestedFieldName, nestedField := range model.Fields {
				logger.Trace(fmt.Sprintf("field %q", nestedFieldName))
				nestedModels, err := b.identifyModelsWithinField(nestedField, allModels, logger.Named(fmt.Sprintf("Model %q / Field %q", *objectDefinition.ReferenceName, nestedFieldName)))
				if err != nil {
					return nil, fmt.Errorf("identifying Models within field %q: %+v", nestedFieldName, err)
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
