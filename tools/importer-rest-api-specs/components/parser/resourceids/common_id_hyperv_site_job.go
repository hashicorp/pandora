// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ commonIdMatcher = commonIdHyperVSiteJob{}

type commonIdHyperVSiteJob struct{}

func (c commonIdHyperVSiteJob) id() importerModels.ParsedResourceId {
	name := "HyperVSiteJob"
	return importerModels.ParsedResourceId{
		CommonAlias: &name,
		Constants:   map[string]resourcemanager.ConstantDetails{},
		Segments: []resourcemanager.ResourceIdSegment{
			importerModels.StaticResourceIDSegment("subscriptions", "subscriptions"),
			importerModels.SubscriptionIDResourceIDSegment("subscriptionId"),
			importerModels.StaticResourceIDSegment("resourceGroups", "resourceGroups"),
			importerModels.ResourceGroupResourceIDSegment("resourceGroupName"),
			importerModels.StaticResourceIDSegment("providers", "providers"),
			importerModels.ResourceProviderResourceIDSegment("resourceProvider", "Microsoft.OffAzure"),
			importerModels.StaticResourceIDSegment("hyperVSites", "hyperVSites"),
			importerModels.UserSpecifiedResourceIDSegment("hyperVSiteName"),
			importerModels.StaticResourceIDSegment("jobs", "jobs"),
			importerModels.UserSpecifiedResourceIDSegment("jobName"),
		},
	}
}
