package parser

import (
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/cleanup"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

// systemAssignedIdentityMatcher matches a model which only supports for SystemAssigned Identity
type systemAssignedIdentityMatcher struct{}

func (m systemAssignedIdentityMatcher) Name() models.FieldDefinitionType {
	return models.SystemAssignedIdentity
}

func (m systemAssignedIdentityMatcher) Match(model models.ModelDetails, resource models.AzureApiResource) bool {
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

	ret := typeOK && principalIdOK && tenantIdOK
	return ret
}

// userAssignedIdentityListMatcher matches a model which only supports for UserAssigned Identity, whose userAssignedIdentities is formed as an array.
type userAssignedIdentityListMatcher struct{}

func (m userAssignedIdentityListMatcher) Name() models.FieldDefinitionType {
	return models.UserAssignedIdentityList
}

func (m userAssignedIdentityListMatcher) Match(model models.ModelDetails, resource models.AzureApiResource) bool {
	var (
		typeOK                   bool
		userAssignedIdentitiesOK bool
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
			userAssignedIdentitiesOK = true
		default:
			return false
		}
	}
	// We didn't check for the 'typeOK' here for some poorly defined Swagger, e.g.:
	// https://github.com/Azure/azure-rest-api-specs/blob/c803720c6bcfcb0fcf4c97f3463ec33a18f9e55c/specification/servicefabricmanagedclusters/resource-manager/Microsoft.ServiceFabricManagedClusters/stable/2021-05-01/nodetype.json#L763
	_ = typeOK
	return userAssignedIdentitiesOK
}

// userAssignedIdentityMapMatcher matches a model which only supports for UserAssigned Identity, whose userAssignedIdentities is formed as a map.
type userAssignedIdentityMapMatcher struct{
	uaiMatcher userAssignedIdentitiesMapMatcher
}

func (m userAssignedIdentityMapMatcher) Name() models.FieldDefinitionType {
	return models.UserAssignedIdentityMap
}

func (m userAssignedIdentityMapMatcher) Match(model models.ModelDetails, resource models.AzureApiResource) bool {
	var (
		typeOK                   bool
		userAssignedIdentitiesOK bool
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
			if !m.uaiMatcher.Match(model, resource) {
				return false
			}
			userAssignedIdentitiesOK = true
		default:
			return false
		}
	}
	return typeOK && userAssignedIdentitiesOK
}


// systemAssignedUserAssignedIdentityListMatcher matches a model which supports both SystemAssigned Identity and UserAssigned Identity whose userAssignedIdentities is formed as an array.
type systemAssignedUserAssignedIdentityListMatcher struct{}

func (m systemAssignedUserAssignedIdentityListMatcher ) Name() models.FieldDefinitionType {
	return models.SystemUserAssignedIdentityList
}

func (m systemAssignedUserAssignedIdentityListMatcher) Match(model models.ModelDetails, resource models.AzureApiResource) bool {
	var (
		typeOK        bool
		principalIdOK bool
		tenantIdOK    bool
		userAssignedIdentitiesOK bool
	)

	for fieldName, field := range model.Fields {
		switch fieldName {
		case "Type":
			if !fieldIsIdentityTypeOfValue(field, resource.Constants, map[string]string{
				"SystemAssigned": "SystemAssigned",
				"UserAssigned": "UserAssigned",
				"SystemAssignedUserAssigned": "SystemAssigned, UserAssigned",
			}) {
				return false
			}
			typeOK = true
		case "PrincipalId":
			principalIdOK = true
		case "TenantId":
			tenantIdOK = true
		case "UserAssignedIdentities":
			if field.Type != models.List {
				return false
			}
			if field.ListElementType == nil || *field.ListElementType != models.String {
				return false
			}
			userAssignedIdentitiesOK = true
		default:
			return false
		}
	}

	ret := typeOK && principalIdOK && tenantIdOK && userAssignedIdentitiesOK
	return ret
}

// systemAssignedUserAssignedIdentityMapMatcher matches a model which supports both SystemAssigned Identity and UserAssigned Identity whose userAssignedIdentities is formed as a map.
type systemAssignedUserAssignedIdentityMapMatcher struct{
	uaiMatcher userAssignedIdentitiesMapMatcher
}

func (m systemAssignedUserAssignedIdentityMapMatcher ) Name() models.FieldDefinitionType {
	return models.SystemUserAssignedIdentityMap
}

func (m systemAssignedUserAssignedIdentityMapMatcher) Match(model models.ModelDetails, resource models.AzureApiResource) bool {
	var (
		typeOK        bool
		principalIdOK bool
		tenantIdOK    bool
		userAssignedIdentitiesOK bool
	)

	for fieldName, field := range model.Fields {
		switch fieldName {
		case "Type":
			if !fieldIsIdentityTypeOfValue(field, resource.Constants, map[string]string{
				"SystemAssigned": "SystemAssigned",
				"UserAssigned": "UserAssigned",
				"SystemAssignedUserAssigned": "SystemAssigned, UserAssigned",
			}) {
				return false
			}
			typeOK = true
		case "PrincipalId":
			principalIdOK = true
		case "TenantId":
			tenantIdOK = true
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
			if !m.uaiMatcher.Match(model, resource) {
				return false
			}
			userAssignedIdentitiesOK = true
		default:
			return false
		}
	}

	ret := typeOK && principalIdOK && tenantIdOK && userAssignedIdentitiesOK
	return ret
}


// userAssignedIdentitiesMapMatcher matches the UserAssigned Identities which is formed as a map.
// This is intended to be nested into customTypeMatcher(s) whose target model embedded a  UserAssignedIdentities in the form of map.
type  userAssignedIdentitiesMapMatcher struct{}

func (m userAssignedIdentitiesMapMatcher) Match(model models.ModelDetails, resource models.AzureApiResource) bool {
	var (
		principalIdOK bool
		clientId      bool
	)

	additionalProps, ok := model.Fields[cleanup.NormalizeName(additionalPropertiesLit)]
	if !ok {
		return false
	}

	if additionalProps.DictValueType == nil || *additionalProps.DictValueType != models.Object || additionalProps.ModelReference == nil {
		return false
	}

	realModel, ok := resource.Models[*additionalProps.ModelReference]
	if !ok {
		return false
	}

	for fieldName := range realModel.Fields {
		switch fieldName {
		case "PrincipalId":
			principalIdOK = true
		case "ClientId":
			clientId = true
		default:
			return false
		}
	}

	return principalIdOK && clientId
}
