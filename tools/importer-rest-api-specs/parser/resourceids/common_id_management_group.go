package resourceids

import "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"

var _ commonIdMatcher = commonIdManagementGroupMatcher{}

type commonIdManagementGroupMatcher struct{}

func (commonIdManagementGroupMatcher) isMatch(input models.ParsedResourceId) bool {
	var managementGroupId = models.ParsedResourceId{
		Constants: map[string]models.ConstantDetails{},
		Segments: []models.ResourceIdSegment{
			{
				Name:       "providers",
				Type:       models.StaticSegment,
				FixedValue: strPtr("providers"),
			},
			{
				Name:       "resourceProvider",
				Type:       models.ResourceProviderSegment,
				FixedValue: strPtr("Microsoft.Management"),
			},
			{
				Name:       "managementGroups",
				Type:       models.StaticSegment,
				FixedValue: strPtr("managementGroups"),
			},
			{
				Name: "groupId",
				Type: models.UserSpecifiedSegment,
			},
		},
	}
	return managementGroupId.Matches(input)
}

func (commonIdManagementGroupMatcher) name() string {
	return "ManagementGroup"
}
