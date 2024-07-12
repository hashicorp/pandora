// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package models

import (
	"strings"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

type AzureApiDefinition struct {
	ServiceName string
	ApiVersion  string
	Resources   map[string]sdkModels.APIResource
}

func (d AzureApiDefinition) IsPreviewVersion() bool {
	lower := strings.ToLower(d.ApiVersion)
	// handles preview, privatepreview and publicpreview
	if strings.Contains(lower, "preview") {
		return true
	}
	if strings.Contains(lower, "beta") {
		return true
	}
	if strings.Contains(lower, "alpha") {
		return true
	}

	return false
}

func MergeResourcesForTag(base, merge sdkModels.APIResource) sdkModels.APIResource {
	for k, v := range merge.Constants {
		if _, ok := base.Constants[k]; !ok {
			base.Constants[k] = v
		}
	}

	for k, v := range merge.Models {
		if _, ok := base.Models[k]; !ok {
			base.Models[k] = v
		}
	}

	for k, v := range merge.Operations {
		if _, ok := base.Operations[k]; !ok {
			base.Operations[k] = v
		}
	}
	for k, v := range merge.ResourceIDs {
		if _, ok := base.ResourceIDs[k]; !ok {
			base.ResourceIDs[k] = v
		}
	}

	// `base.Terraform` and `merge.Terraform` should both be nil here, so we don't process it

	return base
}
