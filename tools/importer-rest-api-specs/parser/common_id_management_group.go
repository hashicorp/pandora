package parser

import "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"

var _ commonIdMatcher = commonIdManagementGroupMatcher{}

type commonIdManagementGroupMatcher struct{}

func (c commonIdManagementGroupMatcher) isMatch(input models.ParsedResourceId) bool {
	var managementGroupId = models.ParsedResourceId{
		Constants: map[string]models.ConstantDetails{},
		Segments: []models.ResourceIdSegment{
			{
				Name:       "providers",
				Type:       models.StaticSegment,
				FixedValue: toPtr("providers"),
			},
			{
				Name:       "resourceProvider",
				Type:       models.ResourceProviderSegment,
				FixedValue: toPtr("resourceProvider"),
			},
			{
				Name:       "managementGroups",
				Type:       models.StaticSegment,
				FixedValue: toPtr("managementGroups"),
			},
			{
				Name: "groupId",
				Type: models.UserSpecifiedSegment,
			},
		},
	}
	return managementGroupId.Matches(input)
}

func (c commonIdManagementGroupMatcher) name() string {
	return "ManagementGroup"
}
