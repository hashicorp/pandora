// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"fmt"
	"sort"
	"strings"

	sdkHelpers "github.com/hashicorp/pandora/tools/data-api-sdk/v1/helpers"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/cleanup"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/comparison"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/resourceids/commonids"
)

func (p *Parser) generateNamesForResourceIds(input []sdkModels.ResourceID, uriToResourceId map[string]ParsedOperation) (map[string]sdkModels.ResourceID, error) {
	return generateNamesForResourceIds(input, uriToResourceId)
}

func generateNamesForResourceIds(input []sdkModels.ResourceID, uriToResourceId map[string]ParsedOperation) (map[string]sdkModels.ResourceID, error) {
	// now that we have all the Resource ID's, we then need to go through and determine Unique ID's for those
	// we need all of them here to avoid conflicts, e.g. AuthorizationRule which can be a NamespaceAuthorizationRule
	// or an EventHubAuthorizationRule, but is named AuthorizationRule in both

	// Before we do anything else, let's go through remove any containing uri suffixes (since these are duplicated without
	// where they contain a Resource ID - and then sort them short -> long for consistency
	uniqueUris := make(map[string]sdkModels.ResourceID, 0)
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

	candidateNamesToUris := make(map[string]sdkModels.ResourceID, 0)
	conflictingNamesToUris := make(map[string][]sdkModels.ResourceID, 0)

	// first detect any CommonIDs and output those, to save the names
	urisThatAreCommonIds := make(map[string]struct{})
	for _, uri := range sortedUris {
		resourceId := uniqueUris[uri]
		for i, commonIdType := range commonids.CommonIDTypes {
			commonId := commonIdType.ID()
			if comparison.ResourceIDsMatch(commonId, resourceId) {
				if commonId.CommonIDAlias == nil {
					return nil, fmt.Errorf("the Common ID %d had no Alias: %+v", i, commonId)
				}
				candidateNamesToUris[*commonId.CommonIDAlias] = resourceId
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
		if resourceId.Segments[0].Type == sdkModels.ScopeResourceIDSegmentType && len(resourceId.Segments) > 1 {
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
			conflictingNamesToUris[candidateSegmentName] = []sdkModels.ResourceID{existingUri, resourceId}
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
				uris = append(uris, sdkHelpers.DisplayValueForResourceID(uri))
			}

			return nil, fmt.Errorf("determining unique names for conflicting uri's %q: %+v", strings.Join(uris, " | "), err)
		}

		for k, v := range uniqueNames {
			conflictUniqueNames[k] = struct{}{}
			candidateNamesToUris[k] = v
		}
	}

	// now we have unique ID's, we should go through and suffix `Id` onto the end of each of them
	outputNamesToUris := make(map[string]sdkModels.ResourceID)
	for k, v := range candidateNamesToUris {
		key := fmt.Sprintf("%sId", cleanup.NormalizeName(k))
		outputNamesToUris[key] = v

		if _, ok := conflictUniqueNames[k]; ok {
			for idx, v2 := range uriToResourceId {
				if v2.ResourceId != nil && comparison.ResourceIDsMatch(*v2.ResourceId, v) && (v2.ResourceIdName != nil && *v2.ResourceIdName != key) {
					v2.ResourceIdName = &key
					uriToResourceId[idx] = v2
				}
			}
		}
	}

	return outputNamesToUris, nil
}

func determineUniqueNamesFor(conflictingUris []sdkModels.ResourceID, existingCandidateNames map[string]sdkModels.ResourceID) (map[string]sdkModels.ResourceID, error) {
	proposedNames := make(map[string]sdkModels.ResourceID)
	for _, resourceId := range conflictingUris {
		availableSegments := SegmentsAvailableForNaming(resourceId)

		proposedName := ""
		uniqueNameFound := false

		// matches the behaviour above
		if resourceId.Segments[0].Type == sdkModels.ScopeResourceIDSegmentType {
			proposedName += "Scoped"
		}

		for _, segment := range availableSegments {
			proposedName = fmt.Sprintf("%s%s", cleanup.NormalizeSegment(segment, false), proposedName)

			uri, hasConflictWithExisting := existingCandidateNames[proposedName]
			if hasConflictWithExisting {
				if comparison.ResourceIDsMatch(uri, resourceId) {
					// it's this ID from a different type
					hasConflictWithExisting = false
				}
			}

			uri, hasConflictWithProposed := proposedNames[proposedName]
			if hasConflictWithProposed {
				if comparison.ResourceIDsMatch(uri, resourceId) {
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

			return nil, fmt.Errorf("not enough segments in %q to determine a unique name - conflicts with %q", sdkHelpers.DisplayValueForResourceID(resourceId), sdkHelpers.DisplayValueForResourceID(conflictingUri))
		}

		proposedNames[proposedName] = resourceId
	}

	return proposedNames, nil
}

func SegmentsAvailableForNaming(pri sdkModels.ResourceID) []string {
	// first reverse the segments, since we want to take from right -> left
	reversedSegments := make([]sdkModels.ResourceIDSegment, 0)
	for i := len(pri.Segments); i > 0; i-- {
		segment := pri.Segments[i-1]
		reversedSegments = append(reversedSegments, segment)
	}

	segmentsWithoutScope := make([]sdkModels.ResourceIDSegment, 0)
	for _, segment := range reversedSegments {
		if segment.Type == sdkModels.ScopeResourceIDSegmentType {
			continue
		}

		segmentsWithoutScope = append(segmentsWithoutScope, segment)
	}

	// if it's an Azure Resource ID (e.g. key-value pairs) (and not just a scope)
	if len(segmentsWithoutScope)%2 == 0 && len(segmentsWithoutScope) > 0 {
		availableSegments := make([]string, 0)
		for _, segment := range segmentsWithoutScope {
			if segment.Type == sdkModels.ConstantResourceIDSegmentType || segment.Type == sdkModels.StaticResourceIDSegmentType {
				normalized := cleanup.NormalizeSegmentName(segment.Name)

				// trim off the `Static` prefix if it's expected to be present
				if segment.Type == sdkModels.ResourceProviderResourceIDSegmentType || segment.Type == sdkModels.StaticResourceIDSegmentType {
					normalized = strings.TrimPrefix(normalized, "Static")
				}

				availableSegments = append(availableSegments, normalized)
			}
		}

		return availableSegments
	}

	availableSegments := make([]string, 0)
	for _, segment := range reversedSegments {
		if segment.Type != sdkModels.UserSpecifiedResourceIDSegmentType {
			continue
		}

		// otherwise use the names of any user specifiable segments
		normalized := cleanup.NormalizeSegmentName(segment.Name)

		// trim off the `Static` prefix if it's expected to be present
		if segment.Type == sdkModels.ResourceProviderResourceIDSegmentType || segment.Type == sdkModels.StaticResourceIDSegmentType {
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
