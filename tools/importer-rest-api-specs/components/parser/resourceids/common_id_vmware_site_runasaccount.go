// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var _ commonIdMatcher = commonIdVMwareSiteRunAsAccount{}

type commonIdVMwareSiteRunAsAccount struct {
}

func (c commonIdVMwareSiteRunAsAccount) id() importerModels.ParsedResourceId {
	name := "VMwareSiteRunAsAccount"
	return importerModels.ParsedResourceId{
		CommonAlias: &name,
		Constants:   map[string]models.SDKConstant{},
		Segments: []models.ResourceIDSegment{
			models.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
			models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			models.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
			models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			models.NewStaticValueResourceIDSegment("providers", "providers"),
			models.NewResourceProviderResourceIDSegment("resourceProvider", "Microsoft.OffAzure"),
			models.NewStaticValueResourceIDSegment("vmwareSites", "vmwareSites"),
			models.NewUserSpecifiedResourceIDSegment("vmwareSiteName", "vmwareSiteName"),
			models.NewStaticValueResourceIDSegment("runAsAccounts", "runAsAccounts"),
			models.NewUserSpecifiedResourceIDSegment("runAsAccountName", "runAsAccountName"),
		},
	}
}
