package resourceids

import "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"

var _ commonIdMatcher = commonIdManagementGroupMatcher{}

type commonIdManagementGroupMatcher struct{}

func (id commonIdManagementGroupMatcher) id() models.ParsedResourceId {
	name := id.name()
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

func (id commonIdManagementGroupMatcher) isMatch(input models.ParsedResourceId) bool {
	var managementGroupId = id.id()
	return managementGroupId.Matches(input)
}

func (commonIdManagementGroupMatcher) name() string {
	return "ManagementGroup"
}
