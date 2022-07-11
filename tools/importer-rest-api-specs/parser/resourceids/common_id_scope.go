package resourceids

import "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"

var _ commonIdMatcher = commonIdScopeMatcher{}

type commonIdScopeMatcher struct{}

func (id commonIdScopeMatcher) id() models.ParsedResourceId {
	name := id.name()
	return models.ParsedResourceId{
		CommonAlias: &name,
		Constants:   map[string]models.ConstantDetails{},
		Segments: []models.ResourceIdSegment{
			models.ScopeResourceIDSegment("scope"),
		},
	}
}

func (id commonIdScopeMatcher) isMatch(input models.ParsedResourceId) bool {
	var scopeId = id.id()
	return scopeId.Matches(input)
}

func (commonIdScopeMatcher) name() string {
	return "Scope"
}
