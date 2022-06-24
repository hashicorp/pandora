package resourceids

import "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"

func (p *Parser) distinctResourceIds(input map[string]processedResourceId) []models.ParsedResourceId {
	out := make([]models.ParsedResourceId, 0)
	for _, v := range input {
		if v.segments == nil {
			continue
		}

		item := models.ParsedResourceId{
			CommonAlias: nil,
			Constants:   v.constants,
			Segments:    *v.segments,
		}

		matchFound := false
		for _, existing := range out {
			if item.Matches(existing) {
				matchFound = true
			}
		}
		if !matchFound {
			out = append(out, item)
		}
	}

	return out
}
