package resourceids

import (
	"fmt"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/featureflags"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/parser/constants"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/parser/internal"
	"log"
	"sort"
	"strings"

	"github.com/go-openapi/spec"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/cleanup"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var knownSegmentsUsedForScope = []string{
	"ResourceId",
	"resourceScope",
	"resourceUri",
	"scope",
	"scopePath",
}

func (result *ResourceIdParseResult) GenerateNames() error {
	// next determine names for these
	namesToResourceUris, urisToNames, err := LegacyDetermineNamesForResourceIds(result.ResourceUrisToMetadata)
	if err != nil {
		return fmt.Errorf("determining names for Resource ID's: %+v", err)
	}
	result.NameToResourceIDs = *namesToResourceUris

	// finally go over the existing results and swap out the Resource ID objects for the Name which should be used
	urisToMetadata, err := mapNamesToResourceIds(*urisToNames, result.ResourceUrisToMetadata)
	if err != nil {
		return fmt.Errorf("mapping names back to Resource ID's: %+v", err)
	}
	result.ResourceUrisToMetadata = *urisToMetadata

	return nil
}

type ResourceUriMetadata struct {
	// ResourceIdName is the name of the ResourceID object, available once the unique names have been
	// identified (if there's a Resource ID)
	ResourceIdName *string

	// ResourceId is the parsed Resource ID object, if any
	ResourceId *models.ParsedResourceId

	// UriSuffix is any suffix which should be applied to the URI
	UriSuffix *string
}

func (p *Parser) LegacyFindResourceIds() (*ResourceIdParseResult, error) {
	result := ResourceIdParseResult{
		NestedResult: internal.ParseResult{
			Constants: map[string]models.ConstantDetails{},
		},

		NameToResourceIDs:      map[string]models.ParsedResourceId{},
		ResourceUrisToMetadata: map[string]ResourceUriMetadata{},
	}

	// first get a list of all of the Resource ID's present in these operations
	// where a Suffix is present on a Resource ID, we'll have 2 entries for the Suffix and the Resource ID directly
	urisToMetadata, nestedResult, err := p.parseResourceIds()
	if err != nil {
		return nil, fmt.Errorf("parsing Resource ID's from Operations: %+v", err)
	}
	result.ResourceUrisToMetadata = *urisToMetadata
	result.NestedResult = *nestedResult

	return &result, nil
}

func (p Parser) parseResourceIds() (*map[string]ResourceUriMetadata, *internal.ParseResult, error) {
	result := internal.ParseResult{
		Constants: map[string]models.ConstantDetails{},
	}
	urisToMetaData := make(map[string]ResourceUriMetadata, 0)

	for _, operation := range p.swaggerSpecExpanded.Operations() {
		for uri, operationDetails := range operation {
			if internal.OperationShouldBeIgnored(uri) {
				continue
			}

			metadata, err := parseResourceIdFromOperation(uri, operationDetails)
			if err != nil {
				return nil, nil, fmt.Errorf("parsing %q: %+v", uri, err)
			}

			// next, if it's based on a Resource ID, let's ensure that's added too
			resourceUri := uri
			if metadata.ResourceId != nil {
				if err := result.AppendConstants(metadata.ResourceId.Constants); err != nil {
					return nil, nil, fmt.Errorf("appending constants from resource id for %s: %+v", uri, err)
				}

				resourceManagerUri := metadata.ResourceId.NormalizedResourceManagerResourceId()
				if strings.EqualFold(resourceUri, resourceManagerUri) {
					// if it's been rewritten (e.g. the RP name fixed) replace the original URI
					resourceUri = resourceManagerUri
				} else {
					urisToMetaData[resourceManagerUri] = ResourceUriMetadata{
						ResourceIdName: metadata.ResourceIdName,
						ResourceId:     metadata.ResourceId,
						UriSuffix:      nil,
					}
				}
			}
			urisToMetaData[resourceUri] = *metadata
		}
	}

	return &urisToMetaData, &result, nil
}

func parseResourceIdFromOperation(uri string, operationDetails *spec.Operation) (*ResourceUriMetadata, error) {
	// TODO: unit tests for this method too
	segments := make([]models.ResourceIdSegment, 0)
	result := internal.ParseResult{
		Constants: map[string]models.ConstantDetails{},
	}

	uriSegments := strings.Split(strings.TrimPrefix(uri, "/"), "/")
	for _, uriSegment := range uriSegments {
		// accounts for double-forward slashes at the start of some URI's
		if uriSegment == "" {
			continue
		}

		originalSegment := uriSegment
		normalizedSegment := normalizeSegment(uriSegment)

		// intentionally check the pre-cut version
		if strings.HasPrefix(originalSegment, "{") && strings.HasSuffix(originalSegment, "}") {
			isScope := false
			for _, scopeSegmentAlias := range knownSegmentsUsedForScope {
				if strings.EqualFold(normalizedSegment, scopeSegmentAlias) {
					isScope = true
					break
				}
			}
			if isScope {
				segments = append(segments, models.ResourceIdSegment{
					Type: models.ScopeSegment,
					Name: normalizedSegment,
				})
				continue
			}

			if strings.EqualFold(normalizedSegment, "subscription") || strings.EqualFold(normalizedSegment, "subscriptionId") {
				previousSegmentWasSubscriptions := false
				if len(segments) > 0 {
					lastSegment := segments[len(segments)-1]
					// the segment before this one should be a static segment `subscriptions`
					if lastSegment.Type == models.StaticSegment && lastSegment.FixedValue != nil && strings.EqualFold(*lastSegment.FixedValue, "subscriptions") {
						previousSegmentWasSubscriptions = true
					}
				}

				if previousSegmentWasSubscriptions {
					segments = append(segments, models.ResourceIdSegment{
						Type: models.SubscriptionIdSegment,
						Name: normalizedSegment,
					})
					continue
				}
			}

			if strings.EqualFold(normalizedSegment, "resourceGroup") || strings.EqualFold(normalizedSegment, "resourceGroupName") {
				previousSegmentWasResourceGroups := false
				if len(segments) > 0 {
					lastSegment := segments[len(segments)-1]
					// the segment before this one should be a static segment `resourceGroups`
					if lastSegment.Type == models.StaticSegment && lastSegment.FixedValue != nil && strings.EqualFold(*lastSegment.FixedValue, "resourceGroups") {
						previousSegmentWasResourceGroups = true
					}
				}

				if previousSegmentWasResourceGroups {
					segments = append(segments, models.ResourceIdSegment{
						Type: models.ResourceGroupSegment,
						Name: normalizedSegment,
					})
					continue
				}
			}

			isConstant := false
			for _, param := range operationDetails.Parameters {
				if strings.EqualFold(param.Name, normalizedSegment) && strings.EqualFold(param.In, "path") {
					if param.Ref.String() != "" {
						return nil, fmt.Errorf("TODO: Enum's aren't supported by Reference right now, but apparently should be for %q", uriSegment)
					}

					if param.Enum != nil {
						// then find the constant itself
						constant, err := constants.MapConstant([]string{param.Type}, param.Name, param.Enum, param.Extensions)
						if err != nil {
							return nil, fmt.Errorf("parsing constant from %q: %+v", uriSegment, err)
						}
						result.Constants[constant.Name] = constant.Details
						segments = append(segments, models.ResourceIdSegment{
							Type:              models.ConstantSegment,
							Name:              normalizedSegment,
							ConstantReference: &constant.Name,
						})
						isConstant = true
						break
					}
				}
			}
			if isConstant {
				continue
			}

			segments = append(segments, models.ResourceIdSegment{
				Type: models.UserSpecifiedSegment,
				Name: normalizedSegment,
			})
			continue
		}

		// if it's a Resource Provider
		if strings.Contains(originalSegment, ".") {
			// some ResourceProviders are defined in lower-case, let's fix that
			resourceProviderValue := cleanup.NormalizeResourceProviderName(originalSegment)

			// prefix this with `static{name}` so that the segment is unique
			// these aren't parsed out anyway, but we need unique names
			normalizedSegment = normalizeSegment(fmt.Sprintf("static%s", strings.Title(resourceProviderValue)))
			segments = append(segments, models.ResourceIdSegment{
				Type:       models.ResourceProviderSegment,
				Name:       normalizedSegment,
				FixedValue: &resourceProviderValue,
			})
			continue
		}

		// prefix this with `static{name}` so that the segment is unique
		// these aren't parsed out anyway, but we need unique names
		normlizedName := normalizeSegment(fmt.Sprintf("static%s", strings.Title(normalizedSegment)))
		segments = append(segments, models.ResourceIdSegment{
			Type:       models.StaticSegment,
			Name:       normlizedName,
			FixedValue: &normalizedSegment,
		})
	}

	output := ResourceUriMetadata{
		ResourceIdName: nil,
		UriSuffix:      nil,
	}

	// UriSuffixes are "operations" on a given Resource ID/URI - for example `/restart`
	// or in the case of List operations /providers/Microsoft.Blah/listAllTheThings
	// we treat these as "operations" on the Resource ID and as such the "segments" should
	// only be for the Resource ID and not for the UriSuffix (which is as an additional field)
	lastUserValueSegment := -1
	for i, segment := range segments {
		// everything else technically is a user configurable component
		if segment.Type != models.StaticSegment && segment.Type != models.ResourceProviderSegment {
			lastUserValueSegment = i
		}
	}
	if lastUserValueSegment >= 0 && len(segments) > lastUserValueSegment+1 {
		suffix := ""
		for _, segment := range segments[lastUserValueSegment+1:] {
			suffix += fmt.Sprintf("/%s", *segment.FixedValue)
		}
		output.UriSuffix = &suffix

		// remove any URI Suffix since this isn't relevant for the ID's
		segments = segments[0 : lastUserValueSegment+1]
	}

	allSegmentsAreStatic := true
	for _, segment := range segments {
		if segment.Type != models.StaticSegment && segment.Type != models.ResourceProviderSegment {
			allSegmentsAreStatic = false
			break
		}
	}
	if allSegmentsAreStatic {
		// if it's not an ARM ID there's nothing to output here, but new up a placeholder
		// to be able to give us a normalized id for the suffix
		pri := models.ParsedResourceId{
			Constants: result.Constants,
			Segments:  segments,
		}
		suffix := pri.NormalizedResourceId()
		output.UriSuffix = &suffix
	} else {
		output.ResourceId = &models.ParsedResourceId{
			Constants: result.Constants,
			Segments:  segments,
		}
	}

	// finally, validate that all of the segments have a unique name
	uniqueNames := make(map[string]struct{}, 0)
	for _, segment := range segments {
		uniqueNames[segment.Name] = struct{}{}
	}
	if len(uniqueNames) != len(segments) && output.ResourceId != nil {
		log.Printf("[DEBUG] Determining Unique Names for Segments..")
		uniquelyNamedSegments, err := determineUniqueNamesForSegments(segments)
		if err != nil {
			return nil, fmt.Errorf("determining unique names for the segments as multiple have the same key: %+v", err)
		}

		output.ResourceId.Segments = *uniquelyNamedSegments
	}

	return &output, nil
}

func determineUniqueNamesForSegments(input []models.ResourceIdSegment) (*[]models.ResourceIdSegment, error) {
	segmentNamesUsed := make(map[string]int, 0)

	output := make([]models.ResourceIdSegment, 0)

	for _, segment := range input {
		existingCount, exists := segmentNamesUsed[segment.Name]
		if !exists {
			// mark the name as used and just append it
			segmentNamesUsed[segment.Name] = 1
			output = append(output, segment)
			continue
		}

		existingCount++
		segmentNamesUsed[segment.Name] = existingCount
		// e.g. `item` then `item2`
		segment.Name = fmt.Sprintf("%s%d", segment.Name, existingCount)
		output = append(output, segment)
	}

	return &output, nil
}

func normalizeSegment(input string) string {
	output := cleanup.RemoveInvalidCharacters(input, false)
	output = cleanup.NormalizeSegment(output, true)
	// the names should always be camelCased, so let's be sure
	output = fmt.Sprintf("%s%s", strings.ToLower(string(output[0])), output[1:])

	if featureflags.ShouldReservedKeywordsBeNormalized {
		output = cleanup.NormalizeReservedKeywords(output)
	}

	return output
}

// LegacyDetermineNamesForResourceIds returns a map[name]ParsedResourceID and map[Uri]Name based on the Resource Manager URI's available
func LegacyDetermineNamesForResourceIds(urisToObjects map[string]ResourceUriMetadata) (*map[string]models.ParsedResourceId, *map[string]string, error) {
	// now that we have all of the Resource ID's, we then need to go through and determine Unique ID's for those
	// we need all of them here to avoid conflicts, e.g. AuthorizationRule which can be a NamespaceAuthorizationRule
	// or an EventHubAuthorizationRule, but is named AuthorizationRule in both

	// Before we do anything else, let's go through remove any containing uri suffixes (since these are duplicated without
	// where they contain a Resource ID - and then sort them short -> long for consistency
	uniqueUris := make(map[string]struct{}, 0)
	for uri, resourceId := range urisToObjects {
		// if it's just a suffix (e.g. root-level ListAll calls) iterate over it
		if resourceId.ResourceId == nil {
			continue
		}

		// when there's a Uri Suffix we should pass in both the full uri and just the resource manager uri so we can
		// skip it if this is a full uri (with a suffix), since the name comes from the resource manager uri instead
		if resourceId.UriSuffix != nil {
			continue
		}

		// if the resourceid matches one that we've already got, then skip it
		matches := false
		for otherUri, otherResourceId := range urisToObjects {
			if uri == otherUri || otherResourceId.ResourceId == nil {
				continue
			}

			if resourceId.ResourceId.Matches(*otherResourceId.ResourceId) {
				if _, otherUriIsParsed := uniqueUris[otherUri]; otherUriIsParsed {
					matches = true
					break
				}
			}
		}
		if matches {
			continue
		}

		uniqueUris[uri] = struct{}{}
	}

	// sort these by length
	sortedUris := make([]string, 0)
	for k := range uniqueUris {
		sortedUris = append(sortedUris, k)
	}
	sort.Slice(sortedUris, func(x, y int) bool {
		return len(sortedUris[x]) < len(sortedUris[y])
	})

	candidateNamesToUris := make(map[string]models.ParsedResourceId, 0)
	conflictingNamesToUris := make(map[string][]models.ParsedResourceId, 0)
	for _, uri := range sortedUris {
		resourceId := urisToObjects[uri]

		// NOTE: these are returned sorted from right to left in URI's, since they're assumed to be hierarchical
		segmentsAvailableForNaming := resourceId.ResourceId.SegmentsAvailableForNaming()
		if len(segmentsAvailableForNaming) == 0 {
			return nil, nil, fmt.Errorf("the uri %q has no segments available for naming", uri)
		}

		candidateSegmentName := segmentsAvailableForNaming[0]
		if resourceId.ResourceId.Segments[0].Type == models.ScopeSegment && len(resourceId.ResourceId.Segments) > 1 {
			candidateSegmentName = fmt.Sprintf("Scoped%s", candidateSegmentName)
		}
		candidateSegmentName = cleanup.NormalizeSegment(candidateSegmentName, false)

		// if we have an existing conflicting key, let's add this to that
		if uris, existing := conflictingNamesToUris[candidateSegmentName]; existing {
			uris = append(uris, *resourceId.ResourceId)
			conflictingNamesToUris[candidateSegmentName] = uris
			continue
		}

		// if there's an existing candidate name for this key, move both this URI and that one to the Conflicts
		if existingUri, existing := candidateNamesToUris[candidateSegmentName]; existing {
			conflictingNamesToUris[candidateSegmentName] = []models.ParsedResourceId{existingUri, *resourceId.ResourceId}
			delete(candidateNamesToUris, candidateSegmentName)
			continue
		}

		// otherwise we have a candidate name we should be able to use, so let's run with it
		candidateNamesToUris[candidateSegmentName] = *resourceId.ResourceId
	}

	// now we need to fix the conflicts
	for _, conflictingUris := range conflictingNamesToUris {
		uniqueNames, err := determineUniqueNamesFor(conflictingUris, candidateNamesToUris)
		if err != nil {
			uris := make([]string, 0)
			for _, uri := range conflictingUris {
				uris = append(uris, uri.String())
			}

			return nil, nil, fmt.Errorf("determining unique names for conflicting uri's %q: %+v", strings.Join(uris, " | "), err)
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

	// finally compose a list of uris -> names so these are easier to map back
	urisToNames := make(map[string]string, 0)
	for k, v := range outputNamesToUris {
		urisToNames[v.NormalizedResourceManagerResourceId()] = k
	}

	return &outputNamesToUris, &urisToNames, nil
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

func mapNamesToResourceIds(urisToNames map[string]string, urisToMetadata map[string]ResourceUriMetadata) (*map[string]ResourceUriMetadata, error) {
	output := make(map[string]ResourceUriMetadata, 0)

	for uri, metadata := range urisToMetadata {
		// ID's with just Suffixes are valid and won't have an ID Type, so skip those
		if metadata.ResourceId == nil {
			output[uri] = metadata
			continue
		}

		name, ok := urisToNames[metadata.ResourceId.NormalizedResourceManagerResourceId()]
		if !ok {
			// there must be a Resource ID for the same Uri with different user specifiable segments
			// so we'll need to loop around urisToMetadata to find it, where the uri != this uri
			for otherUri, otherMetadata := range urisToMetadata {
				if otherUri == uri || otherMetadata.ResourceId == nil {
					continue
				}

				// is it the same Resource ID with a different casing - or is it the same without the UriSuffix
				if metadata.ResourceId.Matches(*otherMetadata.ResourceId) {
					otherName, ok := urisToNames[otherMetadata.ResourceId.NormalizedResourceManagerResourceId()]
					if !ok {
						continue
					}

					name = otherName
				}
			}

			if name == "" {
				return nil, fmt.Errorf("Resource ID <-> Name mapping not found for %q", uri)
			}
		}

		output[metadata.ResourceId.NormalizedResourceManagerResourceId()] = ResourceUriMetadata{
			ResourceIdName: &name,
			// intentionally don't map over the UriSuffix since this is handled below
		}

		// when there's a suffix, we need to output the full uri in the map too
		if metadata.UriSuffix != nil {
			metadata.ResourceIdName = &name
			output[uri] = ResourceUriMetadata{
				ResourceIdName: &name,
				UriSuffix:      metadata.UriSuffix,
			}
		}
	}

	return &output, nil
}
