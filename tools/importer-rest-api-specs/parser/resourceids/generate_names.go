package resourceids

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/parser"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func (p *Parser) generateNamesForResourceIds(input []models.ParsedResourceId) (*map[string]models.ParsedResourceId, error) {
	return generateNamesForResourceIds(input, p.logger)
}

func generateNamesForResourceIds(input []models.ParsedResourceId, log hclog.Logger) (*map[string]models.ParsedResourceId, error) {
	// now that we have all of the Resource ID's, we then need to go through and determine Unique ID's for those
	// we need all of them here to avoid conflicts, e.g. AuthorizationRule which can be a NamespaceAuthorizationRule
	// or an EventHubAuthorizationRule, but is named AuthorizationRule in both

	// Before we do anything else, let's go through remove any containing uri suffixes (since these are duplicated without
	// where they contain a Resource ID - and then sort them short -> long for consistency
	uniqueUris := make(map[string]models.ParsedResourceId, 0)
	sortedUris := make([]string, 0)
	for i := range input {
		resourceId := input[i]
		armId := resourceId.NormalizedResourceManagerResourceId()
		uniqueUris[armId] = resourceId
		sortedUris = append(sortedUris, armId)
	}

	sort.Slice(sortedUris, func(x, y int) bool {
		return len(sortedUris[x]) < len(sortedUris[y])
	})

	candidateNamesToUris := make(map[string]models.ParsedResourceId, 0)
	conflictingNamesToUris := make(map[string][]models.ParsedResourceId, 0)

	// first detect any CommonIDs and output those, to save the names
	urisThatAreCommonIds := make(map[string]struct{})
	for _, uri := range sortedUris {
		resourceId := uniqueUris[uri]
		for i, commonIdType := range commonIdTypes {
			commonId := commonIdType.id()
			if commonId.Matches(resourceId) {
				if commonId.CommonAlias == nil {
					return nil, fmt.Errorf("the Common ID %d had no Alias: %+v", i, commonId)
				}
				candidateNamesToUris[*commonId.CommonAlias] = resourceId
				urisThatAreCommonIds[uri] = struct{}{}
				break
			}
		}
	}

	// then sort the rest
	for _, uri := range sortedUris {
		if _, ok := urisThatAreCommonIds[uri]; ok {
			continue
		}

		resourceId := uniqueUris[uri]

		// NOTE: these are returned sorted from right to left in URI's, since they're assumed to be hierarchical
		segmentsAvailableForNaming := resourceId.SegmentsAvailableForNaming()
		if len(segmentsAvailableForNaming) == 0 {
			return nil, fmt.Errorf("the uri %q has no segments available for naming", uri)
		}

		candidateSegmentName := segmentsAvailableForNaming[0]
		if resourceId.Segments[0].Type == models.ScopeSegment && len(resourceId.Segments) > 1 {
			candidateSegmentName = fmt.Sprintf("Scoped%s", candidateSegmentName)
		}
		candidateSegmentName = parser.NormalizeSegment(candidateSegmentName, false)

		// if we have an existing conflicting key, let's add this to that
		if uris, existing := conflictingNamesToUris[candidateSegmentName]; existing {
			uris = append(uris, resourceId)
			conflictingNamesToUris[candidateSegmentName] = uris
			continue
		}

		// if there's an existing candidate name for this key, move both this URI and that one to the Conflicts
		if existingUri, existing := candidateNamesToUris[candidateSegmentName]; existing {
			conflictingNamesToUris[candidateSegmentName] = []models.ParsedResourceId{existingUri, resourceId}
			delete(candidateNamesToUris, candidateSegmentName)
			continue
		}

		// otherwise we have a candidate name we should be able to use, so let's run with it
		candidateNamesToUris[candidateSegmentName] = resourceId
	}

	// now we need to fix the conflicts
	for _, conflictingUris := range conflictingNamesToUris {
		uniqueNames, err := determineUniqueNamesFor(conflictingUris, candidateNamesToUris)
		if err != nil {
			uris := make([]string, 0)
			for _, uri := range conflictingUris {
				uris = append(uris, uri.String())
			}

			return nil, fmt.Errorf("determining unique names for conflicting uri's %q: %+v", strings.Join(uris, " | "), err)
		}

		for k, v := range *uniqueNames {
			candidateNamesToUris[k] = v
		}
	}

	// now we have unique ID's, we should go through and suffix `Id` onto the end of each of them
	outputNamesToUris := make(map[string]models.ParsedResourceId)
	for k, v := range candidateNamesToUris {
		key := fmt.Sprintf("%sId", k)
		outputNamesToUris[key] = v
	}

	return &outputNamesToUris, nil
}

func determineUniqueNamesFor(conflictingUris []models.ParsedResourceId, existingCandidateNames map[string]models.ParsedResourceId) (*map[string]models.ParsedResourceId, error) {
	proposedNames := make(map[string]models.ParsedResourceId)
	for _, resourceId := range conflictingUris {
		availableSegments := resourceId.SegmentsAvailableForNaming()

		proposedName := ""
		uniqueNameFound := false

		// matches the behaviour above
		if resourceId.Segments[0].Type == models.ScopeSegment {
			proposedName += "Scoped"
		}

		for _, segment := range availableSegments {
			proposedName = fmt.Sprintf("%s%s", parser.NormalizeSegment(segment, false), proposedName)

			uri, hasConflictWithExisting := existingCandidateNames[proposedName]
			if hasConflictWithExisting {
				if uri.Matches(resourceId) {
					// it's this ID from a different type
					hasConflictWithExisting = false
				}
			}

			uri, hasConflictWithProposed := proposedNames[proposedName]
			if hasConflictWithProposed {
				if uri.Matches(resourceId) {
					// it's this ID from a different type
					hasConflictWithProposed = false
				}
			}

			if !hasConflictWithProposed && !hasConflictWithExisting {
				uniqueNameFound = true
				break
			}
		}

		if !uniqueNameFound {
			conflictingUri, hasConflict := existingCandidateNames[proposedName]
			if !hasConflict {
				conflictingUri, hasConflict = proposedNames[proposedName]
			}

			return nil, fmt.Errorf("not enough segments in %q to determine a unique name - conflicts with %q", resourceId.String(), conflictingUri.String())
		}

		proposedNames[proposedName] = resourceId
	}

	return &proposedNames, nil
}
