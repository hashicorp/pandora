package parser

import (
	"reflect"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

// customTypeMatcher tests whether a model matches the schema definition of a custom type.
// Note that each implementation of customTypeMatcher should be mutually exclusive.
type customTypeMatcher interface {
	CustomTypeMatches(model models.ModelDetails, resource models.AzureApiResource) bool
	TypeName() models.FieldDefinitionType
}

// systemAssignedIdentityMatcher matches a model which only supports for SystemAssigned Identity
type systemAssignedIdentityMatcher struct{}

func (m systemAssignedIdentityMatcher) TypeName() models.FieldDefinitionType {
	return models.SystemAssignedIdentity
}

func (m systemAssignedIdentityMatcher) CustomTypeMatches(model models.ModelDetails, resource models.AzureApiResource) bool {
	var (
		typeOK        bool
		principalIdOK bool
		tenantIdOK    bool
	)

	for fieldName, field := range model.Fields {
		switch fieldName {
		case "Type":
			if !fieldIsIdentityTypeOfValue(field, resource.Constants, map[string]string{
				"SystemAssigned": "SystemAssigned",
			}) {
				return false
			}
			typeOK = true
		case "PrincipalId":
			principalIdOK = true
		case "TenantId":
			tenantIdOK = true
		default:
			return false
		}
	}

	return typeOK && principalIdOK && tenantIdOK
}

// userAssignedIdentityListMatcher matches a model which only supports for UserAssigned Identity, which is formed as an array.
type userAssignedIdentityListMatcher struct{}

func (m userAssignedIdentityListMatcher) TypeName() models.FieldDefinitionType {
	return models.UserAssignedIdentityList
}

func (m userAssignedIdentityListMatcher) CustomTypeMatches(model models.ModelDetails, resource models.AzureApiResource) bool {
	var (
		typeOK                  bool
		userAssignedIdentitesOK bool
	)
	for fieldName, field := range model.Fields {
		switch fieldName {
		case "Type":
			if !fieldIsIdentityTypeOfValue(field, resource.Constants, map[string]string{
				"UserAssigned": "UserAssigned",
			}) {
				return false
			}
			typeOK = true
		case "UserAssignedIdentities":
			if field.Type != models.List {
				return false
			}
			if field.ListElementType == nil || *field.ListElementType != models.String {
				return false
			}
			userAssignedIdentitesOK = true
		default:
			return false
		}
	}
	// We didn't check for the 'typeOK' here for some poorly defined Swagger, e.g.:
	// https://github.com/Azure/azure-rest-api-specs/blob/c803720c6bcfcb0fcf4c97f3463ec33a18f9e55c/specification/servicefabricmanagedclusters/resource-manager/Microsoft.ServiceFabricManagedClusters/stable/2021-05-01/nodetype.json#L763
	_ = typeOK
	return userAssignedIdentitesOK
}

// userAssignedIdentityMapMatcher matches a model which only supports for UserAssigned Identity, which is formed as a map.
type userAssignedIdentityMapMatcher struct{}

func (m userAssignedIdentityMapMatcher) TypeName() models.FieldDefinitionType {
	return models.UserAssignedIdentityMap
}

func (m userAssignedIdentityMapMatcher) CustomTypeMatches(model models.ModelDetails, resource models.AzureApiResource) bool {
	var (
		typeOK                  bool
		userAssignedIdentitesOK bool
	)
	for fieldName, field := range model.Fields {
		switch fieldName {
		case "Type":
			if !fieldIsIdentityTypeOfValue(field, resource.Constants, map[string]string{
				"UserAssigned": "UserAssigned",
			}) {
				return false
			}
			typeOK = true
		case "UserAssignedIdentities":
			if field.Type != models.Object {
				return false
			}
			if field.ModelReference == nil {
				return false
			}
			model, ok := resource.Models[*field.ModelReference]
			if !ok {
				return false
			}
			if !m.userAssignedIdentityMatch(model, resource) {
				return false
			}
			userAssignedIdentitesOK = true
		default:
			return false
		}
	}
	return typeOK && userAssignedIdentitesOK
}

func (m userAssignedIdentityMapMatcher) userAssignedIdentityMatch(model models.ModelDetails, resource models.AzureApiResource) bool {
	var (
		principalIdOK bool
		tenantIdOK    bool
	)

	for fieldName := range model.Fields {
		switch fieldName {
		case "PrincipalId":
			principalIdOK = true
		case "TenantId":
			tenantIdOK = true
		default:
			return false
		}
	}

	return principalIdOK && tenantIdOK
}

func fieldIsIdentityTypeOfValue(field models.FieldDefinition, constants map[string]models.ConstantDetails, expect map[string]string) bool {
	if field.Type != models.Object {
		return false
	}
	if field.ConstantReference == nil {
		return false
	}
	constant, ok := constants[*field.ConstantReference]
	if !ok {
		return false
	}
	actual := map[string]string{}
	for k, v := range constant.Values {
		// Some model doesn't define a "None" as an enum value for identity type.
		if k == "None" {
			continue
		}
		actual[k] = v
	}
	return reflect.DeepEqual(actual, expect)
}

func (d *SwaggerDefinition) replaceCustomType(input map[string]models.AzureApiResource) {
	matchers := []customTypeMatcher{
		systemAssignedIdentityMatcher{},
		userAssignedIdentityListMatcher{},
		userAssignedIdentityMapMatcher{},
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
				//       E.g. the "model" might has reference to the "userAssignedIdentities" model.
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
