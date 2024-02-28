package dataworkarounds

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var _ workaround = workaroundTempReadOnlyFields{}

type workaroundTempReadOnlyFields struct {
}

func (w workaroundTempReadOnlyFields) IsApplicable(apiDefinition *models.AzureApiDefinition) bool {
	if apiDefinition.ServiceName == "DevCenter" && apiDefinition.ApiVersion == "2023-04-01" {
		return true
	}

	if apiDefinition.ServiceName == "ManagedIdentity" && apiDefinition.ApiVersion == "2023-01-31" {
		return true
	}

	return false
}

func (w workaroundTempReadOnlyFields) Name() string {
	return "Temp - Mark readonly fields as readonly"
}

func (w workaroundTempReadOnlyFields) Process(apiDefinition models.AzureApiDefinition) (*models.AzureApiDefinition, error) {
	if apiDefinition.ServiceName == "DevCenter" && apiDefinition.ApiVersion == "2023-04-01" {
		resource, ok := apiDefinition.Resources["Projects"]
		if !ok {
			return nil, fmt.Errorf("expected an APIResource `Projects` but didn't get one")
		}
		model, ok := resource.Models["ProjectProperties"]
		if !ok {
			return nil, fmt.Errorf("expected a Model `ProjectProperties` but didn't get one")
		}
		devCenterUri, ok := model.Fields["DevCenterUri"]
		if !ok {
			return nil, fmt.Errorf("expected a Field `DevCenterUri` but didn't get one")
		}
		devCenterUri.Optional = false
		devCenterUri.ReadOnly = true
		devCenterUri.Required = false
		model.Fields["DevCenterUri"] = devCenterUri

		resource.Models["ProjectProperties"] = model
		apiDefinition.Resources["Projects"] = resource
		return &apiDefinition, nil
	}

	if apiDefinition.ServiceName == "ManagedIdentity" && apiDefinition.ApiVersion == "2023-01-31" {
		resource, ok := apiDefinition.Resources["ManagedIdentities"]
		if !ok {
			return nil, fmt.Errorf("expected an APIResource `ManagedIdentities` but didn't get one")
		}

		model, ok := resource.Models["UserAssignedIdentityProperties"]
		if !ok {
			return nil, fmt.Errorf("expected a Model `UserAssignedIdentityProperties` but didn't get one")
		}

		clientId, ok := model.Fields["ClientId"]
		if !ok {
			return nil, fmt.Errorf("expected a Field `ClientId` but didn't get one")
		}
		clientId.Optional = true
		clientId.ReadOnly = true
		model.Fields["ClientId"] = clientId

		principalId, ok := model.Fields["PrincipalId"]
		if !ok {
			return nil, fmt.Errorf("expected a Field `PrincipalId` but didn't get one")
		}
		principalId.Optional = true
		principalId.ReadOnly = true
		model.Fields["PrincipalId"] = principalId

		tenantId, ok := model.Fields["TenantId"]
		if !ok {
			return nil, fmt.Errorf("expected a Field `TenantId` but didn't get one")
		}
		tenantId.Optional = true
		tenantId.ReadOnly = true
		model.Fields["TenantId"] = tenantId

		resource.Models["UserAssignedIdentityProperties"] = model
		apiDefinition.Resources["ManagedIdentities"] = resource
		return &apiDefinition, nil
	}

	return nil, fmt.Errorf("unexpected Service %q / API Version %q", apiDefinition.ServiceName, apiDefinition.ApiVersion)
}
