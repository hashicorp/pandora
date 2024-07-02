// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package models

import (
	"strings"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

type AzureApiDefinition struct {
	ServiceName string
	ApiVersion  string
	Resources   map[string]AzureApiResource
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

type AzureApiResource struct {
	Constants   map[string]models.SDKConstant
	Models      map[string]models.SDKModel
	Operations  map[string]models.SDKOperation
	ResourceIds map[string]models.ResourceID
}

func MergeResourcesForTag(base AzureApiResource, merge AzureApiResource) AzureApiResource {
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
	for k, v := range merge.ResourceIds {
		if _, ok := base.ResourceIds[k]; !ok {
			base.ResourceIds[k] = v
		}
	}

	// `base.Terraform` and `merge.Terraform` should both be nil here, so we don't process it

	return base
}
