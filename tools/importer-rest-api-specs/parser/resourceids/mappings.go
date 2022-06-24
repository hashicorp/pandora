package resourceids

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func (p *Parser) mapProcessedResourceIdsToInputResourceIDs(originalUrisToParsed map[string]processedResourceId, namesToIds map[string]models.ParsedResourceId) (*map[string]ParsedOperation, error) {
	out := make(map[string]ParsedOperation, 0)

	for uri, parsed := range originalUrisToParsed {
		if parsed.segments == nil {
			out[uri] = ParsedOperation{
				ResourceId:     nil,
				ResourceIdName: nil,
				UriSuffix:      parsed.uriSuffix,
			}
			continue
		}

		placeholder := models.ParsedResourceId{
			Constants: parsed.constants,
			Segments:  *parsed.segments,
		}

		found := false
		for name, id := range namesToIds {
			// NOTE: we intentionally use an empty `id` here to avoid comparing on the Alias
			other := models.ParsedResourceId{
				Constants: id.Constants,
				Segments:  id.Segments,
			}
			if placeholder.Matches(other) {
				out[uri] = ParsedOperation{
					ResourceId:     &id,
					ResourceIdName: &name,
					UriSuffix:      parsed.uriSuffix,
				}
				found = true
				break
			}
		}

		if !found {
			return nil, fmt.Errorf("couldn't find the processed ID Name for Resource URI %q", uri)
		}
	}

	return &out, nil
}
