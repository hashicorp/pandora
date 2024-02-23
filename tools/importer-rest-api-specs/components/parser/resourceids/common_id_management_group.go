// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ commonIdMatcher = commonIdManagementGroupMatcher{}

type commonIdManagementGroupMatcher struct{}

func (commonIdManagementGroupMatcher) id() importerModels.ParsedResourceId {
	name := "ManagementGroup"
	return importerModels.ParsedResourceId{
		CommonAlias: &name,
		Constants:   map[string]models.SDKConstant{},
		Segments: []resourcemanager.ResourceIdSegment{
			importerModels.StaticResourceIDSegment("providers", "providers"),
			importerModels.ResourceProviderResourceIDSegment("resourceProvider", "Microsoft.Management"),
			importerModels.StaticResourceIDSegment("managementGroups", "managementGroups"),
			importerModels.UserSpecifiedResourceIDSegment("groupId"),
		},
	}
}
