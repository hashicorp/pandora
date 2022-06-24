package resourceids

import "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"

var _ commonIdMatcher = commonIdScopeMatcher{}

type commonIdScopeMatcher struct{}

func (commonIdScopeMatcher) isMatch(input models.ParsedResourceId) bool {
	var scopeId = models.ParsedResourceId{
		Constants: map[string]models.ConstantDetails{},
		Segments: []models.ResourceIdSegment{
			{
				Name: "scope",
				Type: models.ScopeSegment,
			},
		},
	}
	return scopeId.Matches(input)
}

func (commonIdScopeMatcher) name() string {
	return "Scope"
}
