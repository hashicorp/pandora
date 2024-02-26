// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package models

import (
	"strings"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
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
	Models      map[string]ModelDetails
	Operations  map[string]OperationDetails
	ResourceIds map[string]models.ResourceID
	Terraform   *resourcemanager.TerraformDetails
}

type OperationDetails struct {
	ContentType                      string
	ExpectedStatusCodes              []int
	FieldContainingPaginationDetails *string
	IsListOperation                  bool
	LongRunning                      bool
	Method                           string
	OperationId                      string
	Options                          map[string]models.SDKOperationOption
	RequestObject                    *models.SDKObjectDefinition
	ResourceIdName                   *string
	ResponseObject                   *models.SDKObjectDefinition
	UriSuffix                        *string
}

type ResourceBuildInfo struct {
	Overrides []Override
}

type Override struct {
	Name        string
	UpdatedName *string
	Description *string
}

type ModelDetails struct {
	Description string
	Fields      map[string]FieldDetails

	// @tombuildsstuff: placeholder until the other branch is merged
	ParentTypeName *string
	TypeHintIn     *string
	TypeHintValue  *string
}

type FieldDetails struct {
	Required    bool
	ReadOnly    bool
	Sensitive   bool
	JsonName    string
	Description string

	ObjectDefinition models.SDKObjectDefinition
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
