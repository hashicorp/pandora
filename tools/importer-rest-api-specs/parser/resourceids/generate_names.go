package resourceids

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func (p *Parser) generateNamesForResourceIds(input []models.ParsedResourceId) (*map[string]models.ParsedResourceId, error) {
	// TODO: actual naming
	out := make(map[string]models.ParsedResourceId)
	for i, v := range input {
		out[fmt.Sprintf("%d", i)] = v
	}
	return &out, nil
}
