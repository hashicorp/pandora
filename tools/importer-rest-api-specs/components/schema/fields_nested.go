package schema

import (
	"fmt"
	"log"

	"github.com/hashicorp/go-hclog"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/helpers"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func (b Builder) identifyFieldsWithinPropertiesBlock(schemaModelName string, input operationPayloads, resource *resourcemanager.TerraformResourceDetails, mappings *resourcemanager.MappingDefinition, named hclog.Logger) (*map[string]resourcemanager.TerraformSchemaFieldDefinition, *resourcemanager.MappingDefinition, error) {
	allFields := make(map[string]struct{}, 0)
	propertiesPayloads := input.createReadUpdatePayloadsProperties()
	for _, model := range propertiesPayloads {
		for k, v := range model.Fields {
			if fieldShouldBeIgnored(k, v, b.constants) {
				continue
			}

			allFields[k] = struct{}{}
		}
	}

	out := make(map[string]resourcemanager.TerraformSchemaFieldDefinition, 0)
	for k := range allFields {
		// TODO: pull the right resourcemanager.ModelDetails for naming below

		readField, hasRead := getField(input.readPropertiesPayload, k)
		createField, hasCreate := getField(input.createPropertiesPayload, k)

		var updateField *resourcemanager.FieldDetails
		hasUpdate := false
		if input.updatePropertiesPayload != nil {
			updateField, hasUpdate = getField(*input.updatePropertiesPayload, k)
		}

		// based on this information
		isComputed := false
		isForceNew := false
		isRequired := false
		isOptional := false
		//isWriteOnly := false // TODO: re-enable that

		if !hasCreate && !hasUpdate && hasRead {
			isComputed = true
		}
		if hasCreate || hasUpdate {
			if !hasRead {
				//isWriteOnly = true
				isForceNew = hasUpdate && !updateField.ForceNew
			} else if hasCreate {
				isRequired = createField.Required
				isOptional = createField.Optional
				isForceNew = hasUpdate
			} else if hasUpdate {
				isRequired = updateField.Required
				isOptional = updateField.Optional
				isForceNew = updateField.ForceNew
			}
		}

		var validation *resourcemanager.TerraformSchemaValidationDefinition
		var err error
		if hasCreate {
			validation, err = getFieldValidation(createField.Validation, k)
			if err != nil {
				return nil, nil, fmt.Errorf("retrieving validation for field %q: %+v", k, err)
			}
		}

		fieldNameForTypedModel := ""
		if hasRead {
			fieldNameForTypedModel, err = updateFieldName(k, &input.readPropertiesPayload, resource)
		} else if hasCreate {
			fieldNameForTypedModel, err = updateFieldName(k, &input.createPropertiesPayload, resource)
		} else if hasUpdate {
			fieldNameForTypedModel, err = updateFieldName(k, input.updatePropertiesPayload, resource)
		}

		if err != nil {
			return nil, nil, err
		}

		var inputObjectDefinition resourcemanager.ApiObjectDefinition
		if hasRead {
			inputObjectDefinition = readField.ObjectDefinition
		} else if hasCreate {
			inputObjectDefinition = createField.ObjectDefinition
		} else if hasUpdate {
			inputObjectDefinition = updateField.ObjectDefinition
		}

		schemaFieldName := helpers.ConvertToSnakeCase(fieldNameForTypedModel)
		log.Printf("[DEBUG] Properties Field %q would be output as %q / %q", k, fieldNameForTypedModel, schemaFieldName)

		if !isOptional && !isRequired {
			isComputed = true
			isForceNew = false
		}

		// TODO(@tombuildsstuff): refactor this and the "nested model" field to use the same parser ideally..?!
		definition := resourcemanager.TerraformSchemaFieldDefinition{
			HclName:  schemaFieldName,
			Required: isRequired,
			ForceNew: isForceNew,
			Optional: isOptional,
			Computed: isComputed,
			// this is only used when outputting the mappings
			// 4 types of mappings: Create/Read/Update/Resource ID - all nullable
			// If a Create and Update Mapping are present but a Read isn't it's implicitly WriteOnly
			//WriteOnly: isWriteOnly,
			Validation: validation,
			Documentation: resourcemanager.TerraformSchemaDocumentationDefinition{
				Markdown: "TODO",
			},
		}
		if hasCreate {
			definition.Documentation.Markdown = createField.Description
		} else if hasUpdate {
			definition.Documentation.Markdown = updateField.Description
		} else if hasRead {
			definition.Documentation.Markdown = readField.Description
		}

		objectDefinition, err := b.convertToFieldObjectDefinition(schemaModelName, inputObjectDefinition)
		if err != nil {
			return nil, nil, fmt.Errorf("converting ObjectDefinition for field to a TerraformFieldObjectDefinition: %+v", err)
		}
		definition.ObjectDefinition = *objectDefinition

		mappingsForField := directAssignmentMappingForNestedField(schemaModelName, fieldNameForTypedModel, input, k, hasCreate, hasUpdate, hasRead)
		mappings.Fields = append(mappings.Fields, mappingsForField...)

		out[fieldNameForTypedModel] = definition
	}

	mappings.Fields = append(mappings.Fields, modelToModelMappingBetween(schemaModelName, input.createModelName, "Properties"))
	if input.createModelName != input.readModelName {
		mappings.Fields = append(mappings.Fields, modelToModelMappingBetween(schemaModelName, input.readModelName, "Properties"))
	}
	if input.updatePayload != nil && input.createModelName != *input.updateModelName && input.readModelName != *input.updateModelName {
		mappings.Fields = append(mappings.Fields, modelToModelMappingBetween(schemaModelName, *input.updateModelName, "Properties"))
	}

	return &out, mappings, nil
}

func directAssignmentMappingForNestedField(schemaModelName, schemaModelField string, input operationPayloads, sdkFieldName string, hasCreate bool, hasUpdate bool, hasRead bool) []resourcemanager.FieldMappingDefinition {
	output := make([]resourcemanager.FieldMappingDefinition, 0)
	if hasCreate {
		output = append(output, directAssignmentMappingBetween(schemaModelName, schemaModelField, input.createPropertiesModelName, sdkFieldName))
	}
	if hasRead && input.createPropertiesModelName != input.readPropertiesModelName {
		output = append(output, directAssignmentMappingBetween(schemaModelName, schemaModelField, input.readPropertiesModelName, sdkFieldName))
	}
	if hasUpdate && input.updatePropertiesModelName != nil && input.createPropertiesModelName != *input.updatePropertiesModelName && input.readPropertiesModelName != *input.updatePropertiesModelName {
		output = append(output, directAssignmentMappingBetween(schemaModelName, schemaModelField, *input.updatePropertiesModelName, sdkFieldName))
	}
	return output
}

func (b Builder) findObjectReferenceForField(modelName string, fieldName string) (reference string, definitionType resourcemanager.ApiObjectDefinitionType) {
	if model, ok := b.models[modelName]; ok {
		if field, ok := model.Fields[fieldName]; ok {
			if field.ObjectDefinition.Type == resourcemanager.ReferenceApiObjectDefinitionType {
				reference = *field.ObjectDefinition.ReferenceName
				definitionType = field.ObjectDefinition.Type
			}
			if field.ObjectDefinition.Type == resourcemanager.ListApiObjectDefinitionType {
				// not doing anything with this right now
				if field.ObjectDefinition.NestedItem.Type == resourcemanager.ReferenceApiObjectDefinitionType {
					reference = *field.ObjectDefinition.NestedItem.ReferenceName
				}
				definitionType = field.ObjectDefinition.Type
			}
		}
	}
	return
}
