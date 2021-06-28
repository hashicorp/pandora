package parser

import (
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"reflect"
)

// customTypeMatcher tests whether a model matches the schema definition of a custom type.
// Note that each implementation of customTypeMatcher should be mutually exclusive.
type customTypeMatcher interface {
	CustomTypeMatches(model models.ModelDetails, resource models.AzureApiResource) bool
	TypeName() models.FieldDefinitionType
}

type systemAssignedIdentityMatcher struct{}

func (m systemAssignedIdentityMatcher) TypeName() models.FieldDefinitionType {
	return models.SystemAssignedIdentity
}

func (m systemAssignedIdentityMatcher) CustomTypeMatches(model models.ModelDetails, resource models.AzureApiResource) bool {
	for fieldName, field := range model.Fields {
		switch fieldName {
		case "type":
			if !fieldIsIdentityTypeOfValue(field, resource.Constants, map[string]string{
				"None":           "None",
				"SystemAssigned": "SystemAssigned",
			}) {
				return false
			}
		case "principalId":
			if !fieldReadOnlyString(field) {
				return false
			}
		case "tenantId":
			if !fieldReadOnlyString(field) {
				return false
			}
		default:
			return false
		}
	}

	return true
}

type userAssignedIdentityListMatcher struct{}

func (m userAssignedIdentityListMatcher) TypeName() models.FieldDefinitionType {
	return models.UserAssignedIdentityList
}

func (m userAssignedIdentityListMatcher) CustomTypeMatches(model models.ModelDetails, resource models.AzureApiResource) bool {
	for fieldName, field := range model.Fields {
		switch fieldName {
		case "type":
			if !fieldIsIdentityTypeOfValue(field, resource.Constants, map[string]string{
				"None":         "None",
				"UserAssigned": "UserAssigned",
			}) {
				return false
			}
		case "userAssignedIdentities":
			{
				if !fieldIsUserAssignedIdentitiesList(field, resource.Models) {
					return false
				}
			}
		default:
			return false
		}
	}

	return true
}

func fieldIsUserAssignedIdentitiesList(model models.ModelDetails, resource models.AzureApiResource) bool {
	for fieldName, field := range model.Fields {
		switch fieldName {
		case "type":
			if !fieldIsIdentityTypeOfValue(field, resource.Constants, map[string]string{
				"None":         "None",
				"UserAssigned": "UserAssigned",
			}) {
				return false
			}
		case "userAssignedIdentities":
			if field.ModelReference == nil {
				return false
			}

			model := resource.Models[*field.ModelReference]
			for fieldName, field := range model.Fields {
				switch fieldName {
				// TODO:
				default:
					return false
				}
			}
		default:
			return false
		}
	}
}

func fieldReadOnlyString(field models.FieldDefinition) bool {
	if field.Type != models.String {
		return false
	}
	return field.ReadOnly
}

func fieldIsIdentityTypeOfValue(field models.FieldDefinition, constants map[string]models.ConstantDetails, expect map[string]string) bool {
	if field.Type != models.String {
		return false
	}
	if field.ConstantReference == nil {
		return false
	}
	constant, ok := constants[*field.ConstantReference]
	if !ok {
		return false
	}
	return reflect.DeepEqual(constant.FieldType, expect)
}

func (d *SwaggerDefinition) replaceCustomType(input map[string]models.AzureApiResource) {
	matchers := []customTypeMatcher{
		systemAssignedIdentityMatcher{},
	}

	for resourceName, resource := range input {
		for modelName, model := range resource.Models {
			for _, matcher := range matchers {
				if !matcher.CustomTypeMatches(model, resource) {
					continue
				}
				// Remove the model from the model set
				delete(input[resourceName].Models, modelName)

				// Iterate over all the models' fields, modify any field referencing this model by nil set its ModelReference, and set its Type to the custom type.
				// TODO: Do we need to remove the models that are only referenced by the "model" under iteration?
				//  	 E.g. "identity" (the "model") might reference the "userAssignedIdentities" model exclusively.
				for mName, m := range resource.Models {
					// Skip current model that is deleted from the model set
					if mName == modelName {
						continue
					}
					for fieldName, field := range m.Fields {
						if field.ModelReference == nil || *field.ModelReference != modelName {
							continue
						}
						field.ModelReference = nil
						field.Type = matcher.TypeName()
						m.Fields[fieldName] = field
					}
				}
			}
		}
	}
}
