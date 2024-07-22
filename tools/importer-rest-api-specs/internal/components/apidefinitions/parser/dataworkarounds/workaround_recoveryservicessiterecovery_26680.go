// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"fmt"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ workaround = workaroundRecoveryServicesSiteRecovery26680{}

// workaroundRecoveryServicesSiteRecovery26680 works around the model `CreateCertificateOptions` being
// present within the API but not being documented in the API Definitions - as such this adds the missing
// model/fields to make this useful.
//
// Swagger PR: https://github.com/Azure/azure-rest-api-specs/pull/26680
type workaroundRecoveryServicesSiteRecovery26680 struct {
}

func (w workaroundRecoveryServicesSiteRecovery26680) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	if serviceName != "RecoveryServicesSiteRecovery" {
		return false
	}

	apiVersions := map[string]struct{}{
		"2022-10-01": {},
		"2023-01-01": {},
		"2023-02-01": {},
		"2023-04-01": {},
		"2023-06-01": {},
	}
	if _, apiVersionMatches := apiVersions[apiVersion.APIVersion]; !apiVersionMatches {
		return false
	}

	if _, resourceExists := apiVersions["VaultCertificates"]; !resourceExists {
		return false
	}

	return true
}

func (w workaroundRecoveryServicesSiteRecovery26680) Name() string {
	return "RecoveryServicesSiteRecovery / 26680"
}

func (w workaroundRecoveryServicesSiteRecovery26680) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	resource, ok := input.Resources["VaultCertificates"]
	if !ok {
		return nil, fmt.Errorf("expected a Resource named `VaultCertificates` but didn't get one")
	}

	// 1. Add the missing model
	resource.Models["CertificateCreateOptions"] = sdkModels.SDKModel{
		Fields: map[string]sdkModels.SDKField{
			"ValidityInHours": {
				Required: false,
				JsonName: "validityInHours",
				ObjectDefinition: sdkModels.SDKObjectDefinition{
					Type: sdkModels.IntegerSDKObjectDefinitionType,
				},
			},
		},
	}

	// 2. Add the field referencing the missing model
	model, ok := resource.Models["CertificateRequest"]
	if !ok {
		return nil, fmt.Errorf("expected a Model named `CertificateRequest` but didn't get one")
	}
	model.Fields["CertificateCreateOptions"] = sdkModels.SDKField{
		Required:    false,
		ReadOnly:    false,
		Sensitive:   false,
		JsonName:    "certificateCreateOptions",
		Description: "",
		ObjectDefinition: sdkModels.SDKObjectDefinition{
			ReferenceName: pointer.To("CertificateCreateOptions"),
			Type:          sdkModels.ReferenceSDKObjectDefinitionType,
		},
	}
	resource.Models["CertificateRequest"] = model

	input.Resources["VaultCertificates"] = resource
	return &input, nil
}
