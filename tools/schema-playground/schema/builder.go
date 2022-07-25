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

func (b Builder) Build(input resourcemanager.TerraformResourceDetails, logger hclog.Logger) (*Definition, error) {
	// TODO: we should look to skip any resources containing discriminators initially, for example.
	// TODO: we also need mappings

	createReadUpdateMethods := b.findCreateUpdateReadPayloads(input)
	if createReadUpdateMethods == nil {
		return nil, nil
	}

	// find each of the "common" top level fields, excluding `properties`
	topLevelFields, err := b.identifyTopLevelFields(*createReadUpdateMethods)
	if err != nil {
		return nil, fmt.Errorf("parsing top-level fields from create/read/update: %+v", err)
	}

	schemaFields := make(map[string]FieldDefinition)
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

	fieldsWithinProperties, err := b.identifyFieldsWithinPropertiesBlock(*createReadUpdateMethods)
	if err != nil {
		return nil, fmt.Errorf("parsing fields within the `properties` block for the create/read/update methods: %+v", err)
	}
	for k, v := range *fieldsWithinProperties {
		schemaFields[k] = v
	}

	return &Definition{
		Fields: schemaFields,
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
