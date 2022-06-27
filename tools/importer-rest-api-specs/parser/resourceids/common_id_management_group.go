package resourceids

import "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"

var _ commonIdMatcher = commonIdManagementGroupMatcher{}

type commonIdManagementGroupMatcher struct{}

func (commonIdManagementGroupMatcher) isMatch(input models.ParsedResourceId) bool {
	var managementGroupId = models.ParsedResourceId{
		Constants: map[string]models.ConstantDetails{},
		Segments: []models.ResourceIdSegment{
			models.StaticResourceIDSegment("providers", "providers"),
			models.ResourceProviderResourceIDSegment("resourceProvider", "Microsoft.Management"),
			models.StaticResourceIDSegment("managementGroups", "managementGroups"),
			models.UserSpecifiedResourceIDSegment("groupId"),
		},
	}
	return managementGroupId.Matches(input)
}

func (commonIdManagementGroupMatcher) name() string {
	return "ManagementGroup"
}
