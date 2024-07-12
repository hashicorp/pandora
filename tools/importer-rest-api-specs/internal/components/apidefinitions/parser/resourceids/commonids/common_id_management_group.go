// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package commonids

import (
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ commonIdMatcher = commonIdManagementGroupMatcher{}

type commonIdManagementGroupMatcher struct{}

func (commonIdManagementGroupMatcher) ID() sdkModels.ResourceID {
	name := "ManagementGroup"
	return sdkModels.ResourceID{
		CommonIDAlias: &name,
		ConstantNames: []string{},
		Segments: []sdkModels.ResourceIDSegment{
			sdkModels.NewStaticValueResourceIDSegment("providers", "providers"),
			sdkModels.NewResourceProviderResourceIDSegment("resourceProvider", "Microsoft.Management"),
			sdkModels.NewStaticValueResourceIDSegment("managementGroups", "managementGroups"),
			sdkModels.NewUserSpecifiedResourceIDSegment("groupId", "groupId"),
		},
	}
}
