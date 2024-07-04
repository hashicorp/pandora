// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"fmt"

	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var _ workaround = workaroundTempReadOnlyFields{}

type workaroundTempReadOnlyFields struct {
}

func (w workaroundTempReadOnlyFields) IsApplicable(apiDefinition *importerModels.AzureApiDefinition) bool {
	if apiDefinition.ServiceName == "ContainerService" && apiDefinition.ApiVersion == "2022-09-02-preview" {
		return true
	}

	if apiDefinition.ServiceName == "DevCenter" && apiDefinition.ApiVersion == "2023-04-01" {
		return true
	}

	if apiDefinition.ServiceName == "LoadTestService" && apiDefinition.ApiVersion == "2022-12-01" {
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

func (w workaroundTempReadOnlyFields) Process(apiDefinition importerModels.AzureApiDefinition) (*importerModels.AzureApiDefinition, error) {
	if apiDefinition.ServiceName == "ContainerService" && apiDefinition.ApiVersion == "2022-09-02-preview" {
		definition, err := w.markFieldAsComputed(apiDefinition, "Fleets", "FleetHubProfile", "Fqdn")
		if err != nil {
			return nil, err
		}

		definition, err = w.markFieldAsComputed(*definition, "Fleets", "FleetHubProfile", "KubernetesVersion")
		if err != nil {
			return nil, err
		}

		return definition, nil
	}

	if apiDefinition.ServiceName == "DevCenter" && apiDefinition.ApiVersion == "2023-04-01" {
		definition, err := w.markFieldAsComputed(apiDefinition, "Projects", "ProjectProperties", "DevCenterUri")
		if err != nil {
			return nil, err
		}

		definition, err = w.markFieldAsComputed(*definition, "DevCenters", "DevCenterProperties", "DevCenterUri")
		if err != nil {
			return nil, err
		}

		return definition, nil
	}

	if apiDefinition.ServiceName == "LoadTestService" && apiDefinition.ApiVersion == "2022-12-01" {
		definition, err := w.markFieldAsComputed(apiDefinition, "LoadTests", "LoadTestProperties", "DataPlaneURI")
		if err != nil {
			return nil, err
		}

		return definition, nil
	}

	if apiDefinition.ServiceName == "ManagedIdentity" && apiDefinition.ApiVersion == "2023-01-31" {
		definition, err := w.markFieldAsComputed(apiDefinition, "ManagedIdentities", "UserAssignedIdentityProperties", "ClientId")
		if err != nil {
			return nil, err
		}

		definition, err = w.markFieldAsComputed(*definition, "ManagedIdentities", "UserAssignedIdentityProperties", "PrincipalId")
		if err != nil {
			return nil, err
		}

		definition, err = w.markFieldAsComputed(*definition, "ManagedIdentities", "UserAssignedIdentityProperties", "TenantId")
		if err != nil {
			return nil, err
		}

		return definition, nil
	}

	return nil, fmt.Errorf("unexpected Service %q / API Version %q", apiDefinition.ServiceName, apiDefinition.ApiVersion)
}

func (w workaroundTempReadOnlyFields) markFieldAsComputed(input importerModels.AzureApiDefinition, apiResourceName, modelName, fieldName string) (*importerModels.AzureApiDefinition, error) {
	resource, ok := input.Resources[apiResourceName]
	if !ok {
		return nil, fmt.Errorf("expected an APIResource %q but didn't get one", apiResourceName)
	}
	model, ok := resource.Models[modelName]
	if !ok {
		return nil, fmt.Errorf("expected a Model %q but didn't get one", modelName)
	}
	field, ok := model.Fields[fieldName]
	if !ok {
		return nil, fmt.Errorf("expected a Field %q but didn't get one", fieldName)
	}
	field.Optional = false
	field.ReadOnly = true
	field.Required = false
	field.Sensitive = false
	model.Fields[fieldName] = field

	resource.Models[modelName] = model
	input.Resources[apiResourceName] = resource
	return &input, nil
}
