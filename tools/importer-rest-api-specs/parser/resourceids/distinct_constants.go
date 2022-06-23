package resourceids

import "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"

func (p *Parser) findDistinctConstants(input map[string]models.ParsedResourceId) (*map[string]models.ConstantDetails, error) {
	// TODO: what if there's conflicting constants?

	constants := make(map[string]models.ConstantDetails)
	for _, item := range input {
		for k, v := range item.Constants {
			constants[k] = v
		}
	}

	return &constants, nil
}
