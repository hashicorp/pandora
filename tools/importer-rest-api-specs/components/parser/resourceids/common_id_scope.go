package resourceids

import (
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ commonIdMatcher = commonIdScopeMatcher{}

type commonIdScopeMatcher struct{}

func (commonIdScopeMatcher) id() models.ParsedResourceId {
	name := "Scope"
	return models.ParsedResourceId{
		CommonAlias: &name,
		Constants:   map[string]resourcemanager.ConstantDetails{},
		Segments: []models.ResourceIdSegment{
			models.ScopeResourceIDSegment("scope"),
		},
	}
}
