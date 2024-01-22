// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/cleanup"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func (p *Parser) generateNamesForResourceIds(input []models.ParsedResourceId, uriToResourceId map[string]ParsedOperation) (*map[string]models.ParsedResourceId, error) {
	return generateNamesForResourceIds(input, uriToResourceId)
}

func generateNamesForResourceIds(input []models.ParsedResourceId, uriToResourceId map[string]ParsedOperation) (*map[string]models.ParsedResourceId, error) {
	// now that we have all of the Resource ID's, we then need to go through and determine Unique ID's for those
	// we need all of them here to avoid conflicts, e.g. AuthorizationRule which can be a NamespaceAuthorizationRule
	// or an EventHubAuthorizationRule, but is named AuthorizationRule in both

	// Before we do anything else, let's go through remove any containing uri suffixes (since these are duplicated without
	// where they contain a Resource ID - and then sort them short -> long for consistency
	uniqueUris := make(map[string]models.ParsedResourceId, 0)
	sortedUris := make([]string, 0)
	for i := range input {
		resourceId := input[i]
		armId := normalizedResourceManagerResourceId(resourceId)
		uniqueUris[armId] = resourceId
		sortedUris = append(sortedUris, armId)
	}

	sort.Slice(sortedUris, func(x, y int) bool {
		if len(sortedUris[x]) == len(sortedUris[y]) {
			return sortedUris[x] < sortedUris[y]
		}
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
		segmentsAvailableForNaming := SegmentsAvailableForNaming(resourceId)
		if len(segmentsAvailableForNaming) == 0 {
			return nil, fmt.Errorf("the uri %q has no segments available for naming", uri)
		}

		candidateSegmentName := segmentsAvailableForNaming[0]
		if resourceId.Segments[0].Type == resourcemanager.ScopeSegment && len(resourceId.Segments) > 1 {
			candidateSegmentName = fmt.Sprintf("Scoped%s", candidateSegmentName)
		}
		candidateSegmentName = cleanup.NormalizeSegment(candidateSegmentName, false)

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
	// we also have to update the ResourceIdName in OriginalUrisToResourceIDs
	conflictUniqueNames := map[string]struct{}{}
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
			conflictUniqueNames[k] = struct{}{}
			candidateNamesToUris[k] = v
		}
	}

	// now we have unique ID's, we should go through and suffix `Id` onto the end of each of them
	outputNamesToUris := make(map[string]models.ParsedResourceId)
	for k, v := range candidateNamesToUris {
		key := fmt.Sprintf("%sId", cleanup.NormalizeName(k))
		outputNamesToUris[key] = v

		if _, ok := conflictUniqueNames[k]; ok {
			for idx, v2 := range uriToResourceId {
				if v2.ResourceId != nil && v2.ResourceId.Matches(v) && (v2.ResourceIdName != nil && *v2.ResourceIdName != key) {
					v2.ResourceIdName = &key
					uriToResourceId[idx] = v2
				}
			}
		}
	}

	return &outputNamesToUris, nil
}

func determineUniqueNamesFor(conflictingUris []models.ParsedResourceId, existingCandidateNames map[string]models.ParsedResourceId) (*map[string]models.ParsedResourceId, error) {
	proposedNames := make(map[string]models.ParsedResourceId)
	for _, resourceId := range conflictingUris {
		availableSegments := SegmentsAvailableForNaming(resourceId)

		proposedName := ""
		uniqueNameFound := false

		// matches the behaviour above
		if resourceId.Segments[0].Type == resourcemanager.ScopeSegment {
			proposedName += "Scoped"
		}

		for _, segment := range availableSegments {
			proposedName = fmt.Sprintf("%s%s", cleanup.NormalizeSegment(segment, false), proposedName)

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

func SegmentsAvailableForNaming(pri models.ParsedResourceId) []string {
	// first reverse the segments, since we want to take from right -> left
	reversedSegments := make([]resourcemanager.ResourceIdSegment, 0)
	for i := len(pri.Segments); i > 0; i-- {
		segment := pri.Segments[i-1]
		reversedSegments = append(reversedSegments, segment)
	}

	segmentsWithoutScope := make([]resourcemanager.ResourceIdSegment, 0)
	for _, segment := range reversedSegments {
		if segment.Type == resourcemanager.ScopeSegment {
			continue
		}

		segmentsWithoutScope = append(segmentsWithoutScope, segment)
	}

	// if it's an Azure Resource ID (e.g. key-value pairs) (and not just a scope)
	if len(segmentsWithoutScope)%2 == 0 && len(segmentsWithoutScope) > 0 {
		availableSegments := make([]string, 0)
		for _, segment := range segmentsWithoutScope {
			if segment.Type == resourcemanager.ConstantSegment || segment.Type == resourcemanager.StaticSegment {
				normalized := cleanup.NormalizeSegmentName(segment.Name)

				// trim off the `Static` prefix if it's expected to be present
				if segment.Type == resourcemanager.ResourceProviderSegment || segment.Type == resourcemanager.StaticSegment {
					normalized = strings.TrimPrefix(normalized, "Static")
				}

				availableSegments = append(availableSegments, normalized)
			}
		}

		return availableSegments
	}

	availableSegments := make([]string, 0)
	for _, segment := range reversedSegments {
		if segment.Type != resourcemanager.UserSpecifiedSegment {
			continue
		}

		// otherwise use the names of any user specifiable segments
		normalized := cleanup.NormalizeSegmentName(segment.Name)

		// trim off the `Static` prefix if it's expected to be present
		if segment.Type == resourcemanager.ResourceProviderSegment || segment.Type == resourcemanager.StaticSegment {
			normalized = strings.TrimPrefix(normalized, "Static")
		}

		availableSegments = append(availableSegments, normalized)
	}

	// if it's just a Scope for example, take whatever we've got
	if len(availableSegments) == 0 {
		for _, segment := range reversedSegments {
			normalized := cleanup.NormalizeSegmentName(segment.Name)
			availableSegments = append(availableSegments, normalized)
		}
	}

	return availableSegments
}
