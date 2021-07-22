package parser

import (
	"reflect"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func fieldIsIdentityTypeOfValue(field models.FieldDetails, constants constantDetailsMap, expect map[string]string) bool {
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
		// Some model doesn't define a "None" as an enum value for identity type. So we will skip it for comparison.
		if strings.EqualFold(k, "None") {
			continue
		}
		actual[k] = v
	}
	return reflect.DeepEqual(actual, expect)
}

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
type userAssignedIdentityMapMatcher struct {}

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
			userAssignedIdentitiesOK =  matchUserAssignedIdentity(field, resource)
		default:
			return false
		}
	}
	return typeOK && userAssignedIdentitiesOK
}

// systemAssignedUserAssignedIdentityListMatcher matches a model which supports both SystemAssigned Identity and UserAssigned Identity whose userAssignedIdentities is formed as an array.
type systemAssignedUserAssignedIdentityListMatcher struct{}

func (m systemAssignedUserAssignedIdentityListMatcher) Name() models.FieldDefinitionType {
	return models.SystemUserAssignedIdentityList
}

func (m systemAssignedUserAssignedIdentityListMatcher) Match(model models.ModelDetails, resource models.AzureApiResource) bool {
	var (
		typeOK                   bool
		principalIdOK            bool
		tenantIdOK               bool
		userAssignedIdentitiesOK bool
	)

	for fieldName, field := range model.Fields {
		switch fieldName {
		case "Type":
			if !fieldIsIdentityTypeOfValue(field, resource.Constants, map[string]string{
				"SystemAssigned":             "SystemAssigned",
				"UserAssigned":               "UserAssigned",
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
type systemAssignedUserAssignedIdentityMapMatcher struct {}

func (m systemAssignedUserAssignedIdentityMapMatcher) Name() models.FieldDefinitionType {
	return models.SystemUserAssignedIdentityMap
}

func (m systemAssignedUserAssignedIdentityMapMatcher) Match(model models.ModelDetails, resource models.AzureApiResource) bool {
	var (
		typeOK                   bool
		principalIdOK            bool
		tenantIdOK               bool
		userAssignedIdentitiesOK bool
	)

	for fieldName, field := range model.Fields {
		switch fieldName {
		case "Type":
			if !fieldIsIdentityTypeOfValue(field, resource.Constants, map[string]string{
				"SystemAssigned":             "SystemAssigned",
				"UserAssigned":               "UserAssigned",
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
			userAssignedIdentitiesOK =  matchUserAssignedIdentity(field, resource)
		default:
			return false
		}
	}

	ret := typeOK && principalIdOK && tenantIdOK && userAssignedIdentitiesOK
	return ret
}


func matchUserAssignedIdentity(field models.FieldDetails, resource models.AzureApiResource) bool {
	// The field is either an inlined model or a ref to some other model.
	if field.Type == models.Object && field.ModelReference != nil {
		model, ok := resource.Models[*field.ModelReference]
		if !ok {
			return false
		}

		fieldPtr, ok := model.AsMap()
		if !ok {
			return false
		}
		field = *fieldPtr
	}

	if field.Type != models.Dictionary {
		return false
	}
	if field.DictValueType == nil || *field.DictValueType != models.Object {
		return false
	}
	if field.ModelReference == nil {
		return false
	}

	uaimodel, ok := resource.Models[*field.ModelReference]
	if !ok {
		return false
	}

	var (
		principalIdOK bool
		clientId      bool
	)

	for fieldName := range uaimodel.Fields {
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