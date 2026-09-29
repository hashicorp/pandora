// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ workaround = nullableWorkaround{}

// this is a common workaround for nullable fields
// we can add a workaround later as simple as below before we add nullable support for all resources:
// fleetNullableWorkaround = newNullableWorkaround("AzureFleet", []string{"2024-11-01"}, "Fleets", "VirtualMachineScaleSetOSProfile", "LinuxConfiguration")
// recoveryNullableWorkaround = newNullableWorkaround("RecoveryServicesSiteRecovery", []string{"2024-10-01"}, "ReplicationProtectedItems", "DisableProtectionInputProperties", "ReplicationProviderInput")
type nullableWorkaround struct {
	serviceName string
	apiVersions []string
	resource    string
	model       string
	field       string
}

func newNullableWorkaround(serviceName string, apiVersion []string, resource, model, field string) workaround {
	return nullableWorkaround{
		serviceName: serviceName,
		apiVersions: apiVersion,
		resource:    resource,
		model:       model,
		field:       field,
	}
}

func (n nullableWorkaround) inApiVersion(apiVersion string) bool {
	if len(n.apiVersions) == 0 {
		return true
	}

	for _, version := range n.apiVersions {
		if version == apiVersion {
			return true
		}
	}
	return false
}

func (n nullableWorkaround) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	return serviceName == n.serviceName && n.inApiVersion(apiVersion.APIVersion)
}

func (n nullableWorkaround) Name() string {
	return fmt.Sprintf("Nullable / %s.%s", n.serviceName, n.resource)
}

func (n nullableWorkaround) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	resource, ok := input.Resources[n.resource]
	if !ok {
		return nil, fmt.Errorf("expected a Resource named `%s`", n.resource)
	}

	profile, ok := resource.Models[n.model]
	if !ok {
		return nil, fmt.Errorf("resource %s expected a Model named `%s`", n.resource, n.model)
	}

	conf, ok := profile.Fields[n.field]
	if !ok {
		return nil, fmt.Errorf("model %s.%s expected a Field named `%s`", n.resource, n.model, n.field)
	}
	conf.ObjectDefinition.Nullable = true

	profile.Fields[n.field] = conf
	resource.Models[n.model] = profile
	input.Resources[n.resource] = resource

	return &input, nil
}
