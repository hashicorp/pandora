// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"fmt"
	"sort"
	"strings"

	"github.com/go-openapi/spec"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/cleanup"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/constants"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/internal"
)

var knownSegmentsUsedForScope = []string{
	"billingScope",
	"connectedClusterResourceUri", // HybridAKS
	"customLocationResourceUri",   // HybridAKS
	"denyAssignmentId",
	"ResourceId",
	"resourceScope",
	"resourceUri",
	"roleAssignmentId",
	"scope",
	"scopePath",
}

type processedResourceId struct {
	segments  *[]models.ResourceIDSegment
	uriSuffix *string
	constants map[string]models.SDKConstant
}

func (p *Parser) parseSegmentsForEachOperation() (*map[string]processedResourceId, error) {
	// TODO: document this

	operationIdsToProcessedResourceIds := make(map[string]processedResourceId, 0)
	for _, operation := range p.swaggerSpecExpanded.Operations() {
		for uri, operationDetails := range operation {
			if internal.OperationShouldBeIgnored(uri) {
				p.logger.Debug(fmt.Sprintf("Ignoring %q", uri))
				continue
			}

			p.logger.Trace(fmt.Sprintf("Parsing Segments for %q..", uri))
			resourceId, err := p.parseResourceIdFromOperation(uri, operationDetails)
			if err != nil {
				return nil, fmt.Errorf("parsing Resource ID from Operation for %q: %+v", uri, err)
			}

			operationIdsToProcessedResourceIds[operationDetails.ID] = *resourceId
		}
	}

	return &operationIdsToProcessedResourceIds, nil
}

func (p *Parser) parseResourceIdFromOperation(uri string, operation *spec.Operation) (*processedResourceId, error) {
	// TODO: document this

	segments := make([]models.ResourceIDSegment, 0)
	result := internal.ParseResult{
		Constants: map[string]models.SDKConstant{},
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
				segments = append(segments, models.NewScopeResourceIDSegment(normalizedSegment))
				continue
			}

			if strings.EqualFold(normalizedSegment, "subscription") || strings.EqualFold(normalizedSegment, "subscriptionId") {
				previousSegmentWasSubscriptions := false
				if len(segments) > 0 {
					lastSegment := segments[len(segments)-1]
					// the segment before this one should be a static segment `subscriptions`
					if lastSegment.Type == models.StaticResourceIDSegmentType && lastSegment.FixedValue != nil && strings.EqualFold(*lastSegment.FixedValue, "subscriptions") {
						previousSegmentWasSubscriptions = true
					}
				}

				if previousSegmentWasSubscriptions {
					segments = append(segments, models.NewSubscriptionIDResourceIDSegment(normalizedSegment))
					continue
				}
			}

			if strings.Contains(strings.ToLower(normalizedSegment), "resourcegroup") {
				previousSegmentWasResourceGroups := false
				if len(segments) > 0 {
					lastSegment := segments[len(segments)-1]
					// the segment before this one should be a static segment `resourceGroups`
					if lastSegment.Type == models.StaticResourceIDSegmentType && lastSegment.FixedValue != nil && strings.EqualFold(*lastSegment.FixedValue, "resourceGroups") {
						previousSegmentWasResourceGroups = true
					}
				}

				if previousSegmentWasResourceGroups {
					segments = append(segments, models.NewResourceGroupNameResourceIDSegment(normalizedSegment))
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

						p.logger.Trace(fmt.Sprintf("Found Constant %q with values `%+v`", constant.Name, constant.Details.Values))
						if len(constant.Details.Values) == 1 {
							constantValue := ""
							for _, v := range constant.Details.Values {
								// if it's not a Resource Provider
								if strings.Contains(v, ".") {
									constantValue = v
								} else {
									// we're intentionally calling `cleanup.NormalizeSegment` rather than
									// `normalizeSegment` in this change to avoid stripping special characters
									// which maybe present within this constant value, namely the `$` for `$Default`).
									constantValue = cleanup.NormalizeSegment(v, true)
								}
							}
							// it's a fixed value segment, not a constant - so we'll transform it as such and skip
							segments = append(segments, models.NewStaticValueResourceIDSegment(normalizedSegment, constantValue))
							isConstant = true
							break
						}

						result.Constants[constant.Name] = constant.Details
						firstVal := firstValueForConstant(constant.Details.Values)
						segments = append(segments, models.NewConstantResourceIDSegment(normalizedSegment, constant.Name, firstVal))
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
			segments = append(segments, models.NewUserSpecifiedResourceIDSegment(normalizedSegment, normalizedSegment))
			continue
		}

		// if it's a Resource Provider
		if strings.Contains(originalSegment, ".") {
			// some ResourceProviders are defined in lower-case, let's fix that
			resourceProviderValue := cleanup.NormalizeResourceProviderName(originalSegment)

			// prefix this with `static{name}` so that the segment is unique
			// these aren't parsed out anyway, but we need unique names
			normalizedSegment = normalizeSegment(fmt.Sprintf("static%s", strings.Title(resourceProviderValue)))
			segments = append(segments, models.NewResourceProviderResourceIDSegment(normalizedSegment, resourceProviderValue))
			continue
		}

		// prefix this with `static{name}` so that the segment is unique
		// these aren't parsed out anyway, but we need unique names
		normalizedName := normalizeSegment(fmt.Sprintf("static%s", strings.Title(normalizedSegment)))
		segments = append(segments, models.NewStaticValueResourceIDSegment(normalizedName, normalizedSegment))
	}

	// now that we've parsed all of the URI Segments, let's determine if this contains a Resource ID scope

	// Some Swaggers define Operation URI's which are generic scopes but which use the full Resource ID format
	// rather than a /{scope} parameter, e.g.
	// /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/{parentType}/{parentName}
	//
	// so we want to double-check if this is a matching scope
	if replacement, ok := segmentsContainAResourceManagerScope(segments); ok {
		segments = *replacement
	}

	out := processedResourceId{
		segments:  nil,
		uriSuffix: nil,
		constants: nil,
	}

	// UriSuffixes are "operations" on a given Resource ID/URI - for example `/restart`
	// or in the case of List operations /providers/Microsoft.Blah/listAllTheThings
	// we treat these as "operations" on the Resource ID and as such the "segments" should
	// only be for the Resource ID and not for the URISuffix (which is as an additional field)
	lastUserValueSegment := -1
	for i, segment := range segments {
		// everything else technically is a user configurable component
		if segment.Type != models.StaticResourceIDSegmentType && segment.Type != models.ResourceProviderResourceIDSegmentType {
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
		if segment.Type != models.StaticResourceIDSegmentType && segment.Type != models.ResourceProviderResourceIDSegmentType {
			allSegmentsAreStatic = false
			break
		}
	}
	if allSegmentsAreStatic {
		constantNames := make([]string, 0)
		for k := range result.Constants {
			constantNames = append(constantNames, k)
		}
		sort.Strings(constantNames)

		// if it's not an ARM ID there's nothing to output here, but new up a placeholder
		// to be able to give us a normalized id for the suffix
		pri := models.ResourceID{
			ConstantNames: constantNames,
			Segments:      segments,
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

func firstValueForConstant(input map[string]string) string {
	// because `input` is an unsorted map we want to consistently pick the first alphabetical value
	values := make([]string, 0)
	for _, v := range input {
		values = append(values, v)
	}
	sort.Strings(values)
	return values[0]
}

func segmentsContainAResourceManagerScope(input []models.ResourceIDSegment) (*[]models.ResourceIDSegment, bool) {
	if len(input) < 8 {
		return nil, false
	}

	// a Resource Manager Scope is where a Scope is defined as:
	// > /subscriptions/{}/resourceGroups/{}/providers/Some.ResourceProvider/{}/{}
	// or
	// > /subscriptions/{}/resourceGroups/{}/providers/{}/{}/{}
	// as such, let's check this
	subscriptionsPresent := input[0].Type == models.StaticResourceIDSegmentType && input[0].FixedValue != nil && strings.EqualFold(*input[0].FixedValue, "subscriptions")
	subscriptionIdPresent := input[1].Type == models.SubscriptionIDResourceIDSegmentType
	resourceGroupsPresent := input[2].Type == models.StaticResourceIDSegmentType && input[2].FixedValue != nil && strings.EqualFold(*input[2].FixedValue, "resourceGroups")
	resourceGroupNamePresent := input[3].Type == models.ResourceGroupResourceIDSegmentType
	providersPresent := input[4].Type == models.StaticResourceIDSegmentType && input[4].FixedValue != nil && strings.EqualFold(*input[4].FixedValue, "providers")
	providerPresent := input[5].Type == models.ResourceProviderResourceIDSegmentType || input[5].Type == models.UserSpecifiedResourceIDSegmentType
	resourceTypePresent := input[6].Type == models.UserSpecifiedResourceIDSegmentType || input[6].Type == models.ConstantResourceIDSegmentType
	resourceNamePresent := input[7].Type == models.UserSpecifiedResourceIDSegmentType

	prefixedWithGenericArmId := subscriptionsPresent && subscriptionIdPresent && resourceGroupsPresent && resourceGroupNamePresent && providersPresent && providerPresent && resourceTypePresent && resourceNamePresent
	if prefixedWithGenericArmId {
		output := []models.ResourceIDSegment{
			models.NewScopeResourceIDSegment("scope"),
		}

		// However it can _also_ be a Nested ID, e.g. for a Child Resource nested under a Parent Resource, for example:
		// > /subscriptions/{}/resourceGroups/{}/providers/{}/{}/{}/{}/{}
		// so we also need to check that
		startingIndex := 8
		if len(input) >= 10 {
			nestedResourcePresent := input[8].Type == models.UserSpecifiedResourceIDSegmentType || input[8].Type == models.ConstantResourceIDSegmentType
			nestedResourceNamePresent := input[9].Type == models.UserSpecifiedResourceIDSegmentType
			if nestedResourcePresent && nestedResourceNamePresent {
				startingIndex = 10
			}
		}
		// Continue trimming any user specified segments until we get to actual Resource ID
		// since these can be included in the Scope itself
		for len(input) > startingIndex {
			segment := input[startingIndex]
			if segment.Type != models.UserSpecifiedResourceIDSegmentType {
				break
			}
			startingIndex++
		}
		if len(input) > startingIndex {
			output = append(output, input[startingIndex:]...)
		}
		return &output, true
	}

	return nil, false
}

func determineUniqueNamesForSegments(input []models.ResourceIDSegment) (*[]models.ResourceIDSegment, error) {
	segmentNamesUsed := make(map[string]int, 0)

	output := make([]models.ResourceIDSegment, 0)

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
