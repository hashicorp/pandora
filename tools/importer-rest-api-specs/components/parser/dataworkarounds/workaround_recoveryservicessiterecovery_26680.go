// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"fmt"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var _ workaround = workaroundRecoveryServicesSiteRecovery26680{}

// workaroundRecoveryServicesSiteRecovery26680 works around the model `CreateCertificateOptions` being
// present within the API but not being documented in the API Definitions - as such this adds the missing
// model/fields to make this useful.
//
// Swagger PR: https://github.com/Azure/azure-rest-api-specs/pull/26680
type workaroundRecoveryServicesSiteRecovery26680 struct {
}

func (w workaroundRecoveryServicesSiteRecovery26680) IsApplicable(apiDefinition *models.AzureApiDefinition) bool {
	if apiDefinition.ServiceName != "RecoveryServicesSiteRecovery" {
		return false
	}

	apiVersions := map[string]struct{}{
		"2022-10-01": {},
		"2023-01-01": {},
		"2023-02-01": {},
		"2023-04-01": {},
		"2023-06-01": {},
	}
	if _, apiVersionMatches := apiVersions[apiDefinition.ApiVersion]; !apiVersionMatches {
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

func (w workaroundRecoveryServicesSiteRecovery26680) Process(apiDefinition models.AzureApiDefinition) (*models.AzureApiDefinition, error) {
	resource, ok := apiDefinition.Resources["VaultCertificates"]
	if !ok {
		return nil, fmt.Errorf("expected a Resource named `VaultCertificates` but didn't get one")
	}

	// 1. Add the missing model
	resource.Models["CertificateCreateOptions"] = models.ModelDetails{
		Fields: map[string]models.FieldDetails{
			"ValidityInHours": {
				Required: false,
				JsonName: "validityInHours",
				ObjectDefinition: &models.ObjectDefinition{
					Type: models.ObjectDefinitionInteger,
				},
			},
		},
	}

	// 2. Add the field referencing the missing model
	model, ok := resource.Models["CertificateRequest"]
	if !ok {
		return nil, fmt.Errorf("expected a Model named `CertificateRequest` but didn't get one")
	}
	model.Fields["CertificateCreateOptions"] = models.FieldDetails{
		Required:        false,
		ReadOnly:        false,
		Sensitive:       false,
		JsonName:        "certificateCreateOptions",
		Description:     "",
		CustomFieldType: nil,
		ObjectDefinition: &models.ObjectDefinition{
			ReferenceName: pointer.To("CertificateCreateOptions"),
			Type:          models.ObjectDefinitionReference,
		},
	}
	resource.Models["CertificateRequest"] = model

	apiDefinition.Resources["VaultCertificates"] = resource
	return &apiDefinition, nil
}
