package dataworkarounds

import (
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ workaround = workaroundTempReadOnlyFieldsManagedIdentity{}

type workaroundTempReadOnlyFieldsManagedIdentity struct {
}

func (w workaroundTempReadOnlyFieldsManagedIdentity) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	return serviceName == "ManagedIdentity" && apiVersion.APIVersion == "2023-01-31"
}

func (w workaroundTempReadOnlyFieldsManagedIdentity) Name() string {
	return "Temp - Mark readonly fields as readonly - ManagedIdentity"
}

func (w workaroundTempReadOnlyFieldsManagedIdentity) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	definition, err := markFieldAsComputed(input, "ManagedIdentities", "UserAssignedIdentityProperties", "ClientId")
	if err != nil {
		return nil, err
	}

	definition, err = markFieldAsComputed(*definition, "ManagedIdentities", "UserAssignedIdentityProperties", "PrincipalId")
	if err != nil {
		return nil, err
	}

	definition, err = markFieldAsComputed(*definition, "ManagedIdentities", "UserAssignedIdentityProperties", "TenantId")
	if err != nil {
		return nil, err
	}

	return definition, nil
}
