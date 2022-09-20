package schema

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/helpers"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/schema/processors"

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

		// models should be prefixed with the resource name to avoid conflicts where a model is reused across a package
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

	// TODO: now that we have all of the models for this resource, we should loop through and check what can be cleaned up
	for modelName, model := range schemaModels {
		for _, processor := range processors.ModelRules {
			schemaModels, err = processor.ProcessModel(modelName, model, schemaModels)
			if err != nil {
				return nil, fmt.Errorf("processing models: %+v", err)
			}
		}
	}

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

	// TODO process top level fields at the end?
	// find each of the "common" top level fields, excluding `properties`
	topLevelFields, err := b.identifyTopLevelFields(input.SchemaModelName, *createReadUpdateMethods)
	if err != nil {
		return nil, fmt.Errorf("parsing top-level fields from create/read/update: %+v", err)
	}

	schemaFields := make(map[string]resourcemanager.TerraformSchemaFieldDefinition)
	for k, v := range topLevelFields.toSchema() {
		schemaFields[k] = v
	}

	resourceId, ok := b.resourceIds[input.ResourceIdName]
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

	modelsUsedWithinProperties, err := b.identifyModelsWithinPropertiesBlock(*createReadUpdateMethods, logger.Named("Models within Property Block"))
	if err != nil {
		return nil, fmt.Errorf("identifying models used within the `properties` block for the create/read/update methods: %+v", err)
	}
	if modelsUsedWithinProperties == nil {
		logger.Trace(fmt.Sprintf("a model within the properties block was marked as skip - skipping"))
		return nil, nil
	}

	return &modelParseResult{
		model: resourcemanager.TerraformSchemaModelDefinition{
			Fields: schemaFields,
		},
		nestedModels: *modelsUsedWithinProperties,
	}, nil
}

func (b Builder) identifyModelsWithinPropertiesBlock(payloads operationPayloads, logger hclog.Logger) (*map[string]resourcemanager.ModelDetails, error) {
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
			return nil, fmt.Errorf("identifying models within field %q: %+v", fieldName, err)
		}
		if modelsWithinField == nil {
			logger.Trace(fmt.Sprintf("field %q was marked as ignored (due to discriminated types or similar) - skipping", fieldName))
			return nil, nil
		}

		for k, v := range *modelsWithinField {
			if other, ok := allModels[k]; ok {
				if !modelsMatch(v, other) {
					return nil, fmt.Errorf("duplicate models named %q were parsed with different fields: %+v / %+v", k, v.Fields, other.Fields)
				}
			}

			allModels[k] = v
		}
	}

	return &allModels, nil
}

func modelsMatch(first resourcemanager.ModelDetails, second resourcemanager.ModelDetails) bool {
	// TODO: implement me
	return len(first.Fields) == len(second.Fields)
}

func (b Builder) buildNestedModelDefinition(modelPrefix string, model resourcemanager.ModelDetails, details resourcemanager.TerraformResourceDetails, logger hclog.Logger) (*resourcemanager.TerraformSchemaModelDefinition, error) {
	out := make(map[string]resourcemanager.TerraformSchemaFieldDefinition, 0)

	for k, v := range model.Fields {
		if objectDefinitionShouldBeSkipped(v.ObjectDefinition.Type) {
			continue
		}

		isComputed := !v.Required && !v.Optional
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
		fieldName, err := updateFieldName(k, &model, &details)
		if err != nil {
			return nil, err
		}
		definition.HclName = helpers.ConvertToSnakeCase(fieldName)

		//if validation := v.Validation; validation != nil {
		//	definition.Validation = &resourcemanager.TerraformSchemaValidationDefinition{}
		//	var validationType resourcemanager.TerraformSchemaValidationType
		//	var possibleValues *resourcemanager.TerraformSchemaValidationPossibleValuesDefinition
		//	switch validation.Type {
		//	case resourcemanager.RangeValidation:
		//		validationType = resourcemanager.TerraformSchemaValidationTypePossibleValues
		//		if values := validation.Values; values == nil || len(*values) == 0 {
		//			return nil, fmt.Errorf("field %q had Range Validation type but had no defined values", fieldName)
		//		} else {
		//			t := (*values)[0]
		//			switch t.(type) {
		//			case string:
		//				possibleValues = &resourcemanager.TerraformSchemaValidationPossibleValuesDefinition{
		//					Type:   resourcemanager.TerraformSchemaValidationPossibleValueTypeString,
		//					Values: *values,
		//				}
		//				break
		//
		//			case int, int32, int64:
		//				possibleValues = &resourcemanager.TerraformSchemaValidationPossibleValuesDefinition{
		//					Type:   resourcemanager.TerraformSchemaValidationPossibleValueTypeInt,
		//					Values: *values,
		//				}
		//				break
		//
		//			case float32, float64:
		//				possibleValues = &resourcemanager.TerraformSchemaValidationPossibleValuesDefinition{
		//					Type:   resourcemanager.TerraformSchemaValidationPossibleValueTypeFloat,
		//					Values: *values,
		//				}
		//				break
		//			}
		//		}
		//	}
		//
		//	if validationType == "" {
		//		return nil, fmt.Errorf("failed to determine or unsupported Validation Type for field %q", fieldName)
		//	} else {
		//		definition.Validation.Type = validationType
		//	}
		//
		//	definition.Validation.PossibleValues = possibleValues
		//}
		//
		validation, err := getFieldValidation(v.Validation, fieldName)
		if err != nil {
			return nil, err
		}
		definition.Validation = validation
		out[fieldName] = definition
	}

	return &resourcemanager.TerraformSchemaModelDefinition{
		Fields: out,
	}, nil
}

func (b Builder) findCreateUpdateReadPayloads(input resourcemanager.TerraformResourceDetails) *operationPayloads {
	out := operationPayloads{}

	// Create has to exist
	createOperation, ok := b.operations[input.CreateMethod.MethodName]
	if !ok {
		return nil
	}
	if createOperation.RequestObject == nil || createOperation.RequestObject.Type != resourcemanager.ReferenceApiObjectDefinitionType || createOperation.RequestObject.ReferenceName == nil {
		// we don't generate resources for operations returning lists etc, debatable if we should
		return nil
	}
	createModel, ok := b.models[*createOperation.RequestObject.ReferenceName]
	if !ok {
		return nil
	}
	out.createPayload = createModel

	// Read has to exist
	readOperation, ok := b.operations[input.ReadMethod.MethodName]
	if !ok {
		return nil
	}
	if readOperation.ResponseObject == nil || readOperation.ResponseObject.Type != resourcemanager.ReferenceApiObjectDefinitionType || readOperation.ResponseObject.ReferenceName == nil {
		// we don't generate resources for operations returning lists etc, debatable if we should
		return nil
	}
	readModel, ok := b.models[*readOperation.ResponseObject.ReferenceName]
	if !ok {
		return nil
	}
	out.readPayload = readModel

	// Update doesn't have to exist
	if updateMethod := input.UpdateMethod; updateMethod != nil {
		updateOperation, ok := b.operations[updateMethod.MethodName]
		if !ok {
			return nil
		}
		if updateOperation.RequestObject == nil || updateOperation.RequestObject.Type != resourcemanager.ReferenceApiObjectDefinitionType || updateOperation.RequestObject.ReferenceName == nil {
			// we don't generate resources for operations returning lists etc, debatable if we should
			return nil
		}
		updateModel, ok := b.models[*updateOperation.RequestObject.ReferenceName]
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
