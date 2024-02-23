// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ commonIdMatcher = commonIdHDInsightCluster{}

type commonIdHDInsightCluster struct{}

func (c commonIdHDInsightCluster) id() importerModels.ParsedResourceId {
	name := "HDInsightCluster"
	return importerModels.ParsedResourceId{
		CommonAlias: &name,
		Constants:   map[string]models.SDKConstant{},
		Segments: []resourcemanager.ResourceIdSegment{
			importerModels.StaticResourceIDSegment("subscriptions", "subscriptions"),
			importerModels.SubscriptionIDResourceIDSegment("subscriptionId"),
			importerModels.StaticResourceIDSegment("resourceGroups", "resourceGroups"),
			importerModels.ResourceGroupResourceIDSegment("resourceGroupName"),
			importerModels.StaticResourceIDSegment("providers", "providers"),
			importerModels.ResourceProviderResourceIDSegment("resourceProvider", "Microsoft.HDInsight"),
			importerModels.StaticResourceIDSegment("clusters", "clusters"),
			importerModels.UserSpecifiedResourceIDSegment("clusterName"),
		},
	}
}
