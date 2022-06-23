package resourceids

import "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"

func (p *Parser) distinctResourceIds(input map[string]processedResourceId) []models.ParsedResourceId {
	everything := make([]models.ParsedResourceId, 0)
	for _, v := range input {
		if v.segments == nil {
			continue
		}

		everything = append(everything, models.ParsedResourceId{
			CommonAlias: nil,
			Constants:   v.constants,
			Segments:    *v.segments,
		})
	}

	out := make([]models.ParsedResourceId, 0)
	for i, item := range everything {
		matchFound := false
		for n, item2 := range everything {
			if i == n {
				continue
			}
			if item.Matches(item2) {
				matchFound = true
			}
		}
		if !matchFound {
			out = append(out, item)
		}
	}

	return out
}
