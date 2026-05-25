// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

// workaroundKeyVault42963 is a workaround for a Key Vault API bug where the exact casing
// of permission constant values must be preserved. When removing a Key Vault Access Policy,
// the API requires the request to use the exact same casing for permission values as returned
// in the response. If the SDK normalizes these constants (e.g., LowerCase from TitleCase),
// the API silently fails the request.
//
// Swagger Issue: https://github.com/Azure/azure-rest-api-specs/issues/42963
var _ workaround = workaroundKeyVault42963{}

type workaroundKeyVault42963 struct{}

func (workaroundKeyVault42963) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	return serviceName == "KeyVault" && apiVersion.APIVersion == "2026-02-01"
}

func (workaroundKeyVault42963) Name() string {
	return "KeyVault / 42963"
}

func (workaroundKeyVault42963) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	resource, ok := input.Resources["Vaults"]
	if !ok {
		return nil, fmt.Errorf("expected a Resource named `Vaults` but didn't get one")
	}

	affectedConstants := []string{
		"CertificatePermissions",
		"KeyPermissions",
		"SecretPermissions",
		"StoragePermissions",
	}

	for _, constantName := range affectedConstants {
		constant, ok := resource.Constants[constantName]
		if !ok {
			return nil, fmt.Errorf("expected a Constant named `%s` but didn't get one", constantName)
		}
		constant.SkipNormalization = true
		resource.Constants[constantName] = constant
	}

	input.Resources["Vaults"] = resource

	return &input, nil
}
