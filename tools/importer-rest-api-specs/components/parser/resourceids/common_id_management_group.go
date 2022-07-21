package resourceids

import "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"

var _ commonIdMatcher = commonIdManagementGroupMatcher{}

type commonIdManagementGroupMatcher struct{}

func (commonIdManagementGroupMatcher) id() models.ParsedResourceId {
	name := "ManagementGroup"
	return models.ParsedResourceId{
		CommonAlias: &name,
		Constants:   map[string]models.ConstantDetails{},
		Segments: []models.ResourceIdSegment{
			models.StaticResourceIDSegment("providers", "providers"),
			models.ResourceProviderResourceIDSegment("resourceProvider", "Microsoft.Management"),
			models.StaticResourceIDSegment("managementGroups", "managementGroups"),
			models.UserSpecifiedResourceIDSegment("groupId"),
		},
	}
}
