package resourceids

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/cleanup"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/constants"
	internal2 "github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/internal"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"

	"github.com/go-openapi/spec"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

var knownSegmentsUsedForScope = []string{
	"ResourceId",
	"resourceScope",
	"resourceUri",
	"scope",
	"scopePath",
}

type processedResourceId struct {
	segments  *[]resourcemanager.ResourceIdSegment
	uriSuffix *string
	constants map[string]resourcemanager.ConstantDetails
}

func (p *Parser) parseResourceIdsFromOperations() (*map[string]processedResourceId, error) {
	// TODO: document this

	urisToProcessedIds := make(map[string]processedResourceId)
	for _, operation := range p.swaggerSpecExpanded.Operations() {
		for uri, operationDetails := range operation {
			if internal2.OperationShouldBeIgnored(uri) {
				p.logger.Debug(fmt.Sprintf("Ignoring %q", uri))
				continue
			}

			p.logger.Trace(fmt.Sprintf("Parsing Segments for %q..", uri))
			resourceId, err := p.parseResourceIdFromOperation(uri, operationDetails)
			if err != nil {
				return nil, fmt.Errorf("parsing Resource ID from Operation for %q: %+v", uri, err)
			}
			urisToProcessedIds[uri] = *resourceId
		}
	}

	return &urisToProcessedIds, nil
}

func (p *Parser) parseResourceIdFromOperation(uri string, operation *spec.Operation) (*processedResourceId, error) {
	// TODO: document this

	segments := make([]resourcemanager.ResourceIdSegment, 0)
	result := internal2.ParseResult{
		Constants: map[string]resourcemanager.ConstantDetails{},
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
				segments = append(segments, models.ScopeResourceIDSegment(normalizedSegment))
				continue
			}

			if strings.EqualFold(normalizedSegment, "subscription") || strings.EqualFold(normalizedSegment, "subscriptionId") {
				previousSegmentWasSubscriptions := false
				if len(segments) > 0 {
					lastSegment := segments[len(segments)-1]
					// the segment before this one should be a static segment `subscriptions`
					if lastSegment.Type == resourcemanager.StaticSegment && lastSegment.FixedValue != nil && strings.EqualFold(*lastSegment.FixedValue, "subscriptions") {
						previousSegmentWasSubscriptions = true
					}
				}

				if previousSegmentWasSubscriptions {
					segments = append(segments, models.SubscriptionIDResourceIDSegment(normalizedSegment))
					continue
				}
			}

			if strings.EqualFold(normalizedSegment, "resourceGroup") || strings.EqualFold(normalizedSegment, "resourceGroupName") {
				previousSegmentWasResourceGroups := false
				if len(segments) > 0 {
					lastSegment := segments[len(segments)-1]
					// the segment before this one should be a static segment `resourceGroups`
					if lastSegment.Type == resourcemanager.StaticSegment && lastSegment.FixedValue != nil && strings.EqualFold(*lastSegment.FixedValue, "resourceGroups") {
						previousSegmentWasResourceGroups = true
					}
				}

				if previousSegmentWasResourceGroups {
					segments = append(segments, models.ResourceGroupResourceIDSegment(normalizedSegment))
					continue
				}
			}

			isConstant := false
			for _, param := range operation.Parameters {
				if strings.EqualFold(param.Name, normalizedSegment) && strings.EqualFold(param.In, "path") {
					if param.Ref.String() != "" {
						return nil, fmt.Errorf("TODO: Enum's aren't supported by Reference right now, but apparently should be for %q", uriSegment)
					}

					if param.Enum != nil {
						// then find the constant itself
						constant, err := constants.MapConstant([]string{param.Type}, param.Name, param.Enum, param.Extensions, p.logger.Named("Constant Parser"))
						if err != nil {
							return nil, fmt.Errorf("parsing constant from %q: %+v", uriSegment, err)
						}

						if len(constant.Details.Values) == 1 {
							constantValue := ""
							for _, v := range constant.Details.Values {
								constantValue = v
							}
							// it's a fixed value segment, not a constant - so we'll transform it as such and skip
							segments = append(segments, resourcemanager.ResourceIdSegment{
								Type:       resourcemanager.StaticSegment,
								Name:       normalizedSegment,
								FixedValue: &constantValue,
							})
							isConstant = true
							break
						}

						result.Constants[constant.Name] = constant.Details
						segments = append(segments, models.ConstantResourceIDSegment(normalizedSegment, constant.Name))
						isConstant = true
						break
					}
				}
			}
			if isConstant {
				continue
			}

			// user specified segments are output as variables, so we need to ensure these aren't language keywords
			normalizedSegment = cleanup.NormalizeReservedKeywords(normalizedSegment)
			segments = append(segments, models.UserSpecifiedResourceIDSegment(normalizedSegment))
			continue
		}

		// if it's a Resource Provider
		if strings.Contains(originalSegment, ".") {
			// some ResourceProviders are defined in lower-case, let's fix that
			resourceProviderValue := cleanup.NormalizeResourceProviderName(originalSegment)

			// prefix this with `static{name}` so that the segment is unique
			// these aren't parsed out anyway, but we need unique names
			normalizedSegment = normalizeSegment(fmt.Sprintf("static%s", strings.Title(resourceProviderValue)))
			segments = append(segments, models.ResourceProviderResourceIDSegment(normalizedSegment, resourceProviderValue))
			continue
		}

		// prefix this with `static{name}` so that the segment is unique
		// these aren't parsed out anyway, but we need unique names
		normalizedName := normalizeSegment(fmt.Sprintf("static%s", strings.Title(normalizedSegment)))
		segments = append(segments, models.StaticResourceIDSegment(normalizedName, normalizedSegment))
	}

	out := processedResourceId{
		segments:  nil,
		uriSuffix: nil,
		constants: nil,
	}

	// UriSuffixes are "operations" on a given Resource ID/URI - for example `/restart`
	// or in the case of List operations /providers/Microsoft.Blah/listAllTheThings
	// we treat these as "operations" on the Resource ID and as such the "segments" should
	// only be for the Resource ID and not for the UriSuffix (which is as an additional field)
	lastUserValueSegment := -1
	for i, segment := range segments {
		// everything else technically is a user configurable component
		if segment.Type != resourcemanager.StaticSegment && segment.Type != resourcemanager.ResourceProviderSegment {
			lastUserValueSegment = i
		}
	}
	if lastUserValueSegment >= 0 && len(segments) > lastUserValueSegment+1 {
		suffix := ""
		for _, segment := range segments[lastUserValueSegment+1:] {
			suffix += fmt.Sprintf("/%s", *segment.FixedValue)
		}
		out.uriSuffix = &suffix

		// remove any URI Suffix since this isn't relevant for the ID's
		segments = segments[0 : lastUserValueSegment+1]
	}

	allSegmentsAreStatic := true
	for _, segment := range segments {
		if segment.Type != resourcemanager.StaticSegment && segment.Type != resourcemanager.ResourceProviderSegment {
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
		suffix := normalizedResourceId(pri.Segments)
		out.uriSuffix = &suffix
	} else {
		out.constants = result.Constants
		out.segments = &segments
	}

	// finally, validate that all of the segments have a unique name
	uniqueNames := make(map[string]struct{}, 0)
	for _, segment := range segments {
		uniqueNames[segment.Name] = struct{}{}
	}
	if len(uniqueNames) != len(segments) && out.segments != nil {
		p.logger.Trace("[DEBUG] Determining Unique Names for Segments..")
		uniquelyNamedSegments, err := determineUniqueNamesForSegments(segments)
		if err != nil {
			return nil, fmt.Errorf("determining unique names for the segments as multiple have the same key: %+v", err)
		}

		out.segments = uniquelyNamedSegments
	}

	return &out, nil
}

func determineUniqueNamesForSegments(input []resourcemanager.ResourceIdSegment) (*[]resourcemanager.ResourceIdSegment, error) {
	segmentNamesUsed := make(map[string]int, 0)

	output := make([]resourcemanager.ResourceIdSegment, 0)

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

	return output
}
