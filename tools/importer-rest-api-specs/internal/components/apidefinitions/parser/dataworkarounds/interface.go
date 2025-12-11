// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"

// workaround defines a workaround for a given set of data, allowing for the parsed data to be
// patched to workaround issues. This is intended only as a short-term workaround, and wants to
// be accompanied by a matching workaround upstream.
type workaround interface {
	// IsApplicable determines whether this workaround is applicable for this Service / APIVersion
	IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool

	// Name returns the Service Name and associated Pull Request number associated with this workaround
	Name() string

	// Process takes the APIVersion and applies the workaround to it
	Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error)
}
