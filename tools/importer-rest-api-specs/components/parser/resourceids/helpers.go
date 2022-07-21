package resourceids

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/cleanup"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func normalizedResourceManagerResourceId(pri models.ParsedResourceId) string {
	segments := segmentsWithoutUriSuffix(pri)
	return normalizedResourceId(segments)
}

func segmentsWithoutUriSuffix(pri models.ParsedResourceId) []models.ResourceIdSegment {
	segments := pri.Segments
	lastUserValueSegment := -1
	for i, segment := range segments {
		// everything else technically is a user configurable component
		if segment.Type != resourcemanager.StaticSegment && segment.Type != resourcemanager.ResourceProviderSegment {
			lastUserValueSegment = i
		}
	}
	if lastUserValueSegment >= 0 && len(segments) > lastUserValueSegment+1 {
		// remove any URI Suffix since this isn't relevant for the ID's
		segments = segments[0 : lastUserValueSegment+1]
	}
	return segments
}

func normalizedResourceId(segments []models.ResourceIdSegment) string {
	components := make([]string, 0)
	for _, segment := range segments {
		switch segment.Type {
		case resourcemanager.ResourceProviderSegment:
			{
				normalizedSegment := cleanup.NormalizeResourceProviderName(*segment.FixedValue)
				components = append(components, normalizedSegment)
				continue
			}

		case resourcemanager.StaticSegment:
			{
				normalizedSegment := cleanup.NormalizeSegment(*segment.FixedValue, true)
				components = append(components, normalizedSegment)
				continue
			}

		case resourcemanager.ConstantSegment, resourcemanager.ResourceGroupSegment, resourcemanager.ScopeSegment, resourcemanager.SubscriptionIdSegment, resourcemanager.UserSpecifiedSegment:
			// e.g. {example}
			normalizedSegment := segment.Name
			normalizedSegment = cleanup.NormalizeReservedKeywords(segment.Name)
			components = append(components, fmt.Sprintf("{%s}", normalizedSegment))
			continue

		default:
			panic(fmt.Sprintf("unimplemented segment type %q", string(segment.Type)))
		}
	}

	return fmt.Sprintf("/%s", strings.Join(components, "/"))
}
