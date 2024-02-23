// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var _ commonIdMatcher = commonIdVMwareSiteJob{}

type commonIdVMwareSiteJob struct {
}

func (c commonIdVMwareSiteJob) id() importerModels.ParsedResourceId {
	name := "VMwareSiteJob"
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
			models.NewStaticValueResourceIDSegment("jobs", "jobs"),
			models.NewUserSpecifiedResourceIDSegment("jobName", "jobName"),
		},
	}
}
