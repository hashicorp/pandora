package resourceids

import (
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/internal"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func (p *Parser) findDistinctConstants(input map[string]models.ParsedResourceId) (*map[string]resourcemanager.ConstantDetails, error) {
	intermediate := internal.ParseResult{
		Constants: map[string]resourcemanager.ConstantDetails{},
	}

	for _, item := range input {
		intermediate.AppendConstants(item.Constants)
	}

	return &intermediate.Constants, nil
}
