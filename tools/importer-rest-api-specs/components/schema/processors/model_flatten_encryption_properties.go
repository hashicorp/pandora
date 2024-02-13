package processors

import (
	"fmt"
	"log"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ ModelProcessor = modelFlattenEncryptionProperties{}

type modelFlattenEncryptionProperties struct{}

func (m modelFlattenEncryptionProperties) ProcessModel(modelName string, model resourcemanager.TerraformSchemaModelDefinition, models map[string]resourcemanager.TerraformSchemaModelDefinition, mappings resourcemanager.MappingDefinition) (*map[string]resourcemanager.TerraformSchemaModelDefinition, *resourcemanager.MappingDefinition, error) {
	/*
			In this function:
			1. Update the model
			2. Update the mappings

			Elsewhere:
			3. Update the acceptance test generator to account for this

			For later:
			* (Chat with Steph) Consider adding a new mapping type for static value (that is, where a constant has one fixed value such
		      as `UserAssigned` we should set it into the state) so that we don't need to add this to the schema. This would allow us to
		      remove the `type` field and set that automatically.
	*/

	// Question: is this API payload consistent for other resources too, or just load test?
	// If so, we should make this only for Load Test (and rename this processor struct appropriately)
	if !strings.HasSuffix(strings.ToLower(modelName), "encryptionproperties") {
		return &models, &mappings, nil
	}
	model, ok := models[modelName]
	if !ok {
		return nil, nil, fmt.Errorf("the model %q was not found", modelName)
	}
	// validate that the model looks as we're expecting else we'll bail
	if len(model.Fields) != 2 {
		return &models, &mappings, nil
	}
	identityBlock, ok := model.Fields["Identity"]
	if !ok || identityBlock.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeReference || identityBlock.ObjectDefinition.ReferenceName == nil {
		return &models, &mappings, nil
	}

	keyUri, ok := model.Fields["KeyUrl"]
	if !ok || keyUri.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeString {
		return &models, &mappings, nil
	}

	identityModel, ok := models[*identityBlock.ObjectDefinition.ReferenceName]
	if !ok {
		return nil, nil, fmt.Errorf("the referenced model %q was not found", *identityBlock.ObjectDefinition.ReferenceName)
	}

	if len(identityModel.Fields) != 2 {
		return &models, &mappings, nil
	}

	typeModel, ok := identityModel.Fields["Type"]
	if !ok || typeModel.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeString {
		return &models, &mappings, nil
	}

	userAssignedIdentity, ok := identityModel.Fields["UserAssignedIdentityId"]
	if !ok || userAssignedIdentity.ObjectDefinition.Type != resourcemanager.TerraformSchemaFieldTypeString {
		return &models, &mappings, nil
	}

	newEncryptionPropertiesModel := make(map[string]resourcemanager.TerraformSchemaFieldDefinition, 0)
	newEncryptionPropertiesModel["UserAssignedIdentityId"] = userAssignedIdentity
	newEncryptionPropertiesModel["KeyVaultKeyUri"] = keyUri
	models[modelName] = resourcemanager.TerraformSchemaModelDefinition{Fields: newEncryptionPropertiesModel}

	for i, field := range mappings.Fields {
		if field.Type != resourcemanager.DirectAssignmentMappingDefinitionType {
			continue
		}

		if field.DirectAssignment == nil {
			continue
		}

		if field.DirectAssignment.SchemaFieldPath == "KeyUrl" {
			field.DirectAssignment.SchemaFieldPath = "KeyVaultKeyId"
		}

		if field.DirectAssignment.SdkFieldPath == "KeyUrl" {
			field.DirectAssignment.SdkFieldPath = "KeyVaultKeyId"
		}

		mappings.Fields[i] = field
	}

	for _, field := range mappings.Fields {
		log.Printf("\n\nField: %+v\n\n", field)

	}

	return &models, &mappings, nil
}
