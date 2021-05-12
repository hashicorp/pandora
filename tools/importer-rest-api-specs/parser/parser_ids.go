package parser

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/cleanup"
)

type parsedResourceId struct {
	// armResourceId is a URI of matching key-value pairs for example
	// /resources/foo/myThing/thing - where `foo` and `thing` are placeholders
	armResourceId *string

	// suffix is any uri which should be appended onto the resourceId, for example /restart
	suffix *string
}

func parsedResourceIdForOperationUri(input operationUri) parsedResourceId {
	id := parsedResourceId{}
	// find the ARM ID that this operation is nested under, for example `/virtualMachines/{name}/restart` is
	// nested under `/virtualMachines/{name}`
	if armUri := input.findTopLevelArmResourceId(); armUri != nil {
		id.armResourceId = armUri
		fullUri := input.normalizedUri()
		suffix := strings.TrimPrefix(fullUri, *armUri)
		if suffix != "" {
			id.suffix = &suffix
		}
	} else {
		normalizedUri := input.normalizedUri()
		id.suffix = &normalizedUri
	}
	return id
}

type parsedResourceIDs struct {
	NamesToResourceIds map[string]string
	UriToDetails       map[string]idDetails
}

type idDetails struct {
	resourceIdName *string
	suffix         *string
}

func (d *SwaggerDefinition) findResourceIdsForTag(tag *string) (*parsedResourceIDs, error) {
	uniqueUris := make(map[string]parsedResourceId)
	uniqueArmUris := make(map[string]struct{}, 0)
	for _, operation := range d.swaggerSpecExpanded.Operations() {
		for uri, operationDetails := range operation {
			if !operationMatchesTag(operationDetails, tag) {
				continue
			}

			// the Swagger data is inconsistent and changes over time - normalize the segments on our side to avoid that
			// this also helps us keep a consistent resourceId
			parsedUri := newOperationUri(uri)
			if parsedUri.shouldBeIgnored() {
				continue
			}

			id := parsedResourceIdForOperationUri(parsedUri)
			if id.armResourceId != nil {
				uniqueArmUris[*id.armResourceId] = struct{}{}
			}

			normalizedUri := parsedUri.normalizedUri()
			uniqueUris[normalizedUri] = id
		}
	}

	// now we need to go through and determine candidate names for these Resource ID's
	// we can do this using the last user configurable segment
	// first let's go through and determine if we have any conflicting 'key' segments
	knownSegments := make(map[string]string)     // map[name]uri
	conflictingKeys := make(map[string][]string) // map[name]uris
	for armUri := range uniqueArmUris {
		parsed := newOperationUri(armUri)
		segmentName := parsed.userSpecifiableSegmentName()
		segment := normalizeSegmentName(*segmentName)
		segment = segment + "Id"
		if v, ok := conflictingKeys[strings.ToLower(segment)]; ok {
			v = append(v, armUri)
			conflictingKeys[strings.ToLower(segment)] = v
			continue
		}

		if existingUri, ok := knownSegments[segment]; ok {
			conflictingKeys[strings.ToLower(segment)] = []string{existingUri, armUri}
			delete(knownSegments, segment)
			continue
		}

		knownSegments[segment] = armUri
	}

	// at this stage knownSegments contains the unique names : uris
	// so we need to iterate over conflictingKeys and find unique names for those
	if len(conflictingKeys) > 0 {
		uniqueSegments, err := determineUniqueSegmentNames(conflictingKeys)
		if err != nil {
			return nil, fmt.Errorf("determining unique segment names: %+v", err)
		}
		for k, v := range *uniqueSegments {
			knownSegments[k] = v
		}
	}

	// finally map URI's to names so this can be used in operations
	urisToDetails := make(map[string]idDetails, 0)
	for normalizedUri, v := range uniqueUris {
		var resourceIdName *string
		if v.armResourceId != nil {
			for name, uri := range knownSegments {
				if uri == *v.armResourceId {
					resourceIdName = &name
					break
				}
			}

			if resourceIdName == nil {
				return nil, fmt.Errorf("finding the Resource ID Key for %q", *v.armResourceId)
			}
		}

		urisToDetails[normalizedUri] = idDetails{
			resourceIdName: resourceIdName,
			suffix:         v.suffix,
		}
	}

	for k, v := range knownSegments {
		uri := newOperationUri(v)
		rid := parsedResourceIdForOperationUri(uri)

		urisToDetails[uri.normalizedUri()] = idDetails{
			resourceIdName: &k,
			suffix:         rid.suffix,
		}
	}

	output := parsedResourceIDs{
		NamesToResourceIds: knownSegments,
		UriToDetails:       urisToDetails,
	}
	return &output, nil
}

func normalizeSegmentName(input string) string {
	output := input
	output = cleanup.NormalizeName(output)

	// todo: something better than this
	if strings.HasSuffix(output, "s") {
		output = strings.TrimSuffix(output, "s")
	}

	output = strings.Title(output)
	return output
}

func determineUniqueSegmentNames(input map[string][]string) (*map[string]string, error) {
	identifiers := make(map[string]string, 0)
	for _, uris := range input {
		proposed := make(map[string]string)
		for _, uri := range uris {
			parsed := newOperationUri(uri)
			names, err := parsed.userSpecifiableSegments()
			if err != nil {
				return nil, fmt.Errorf("finding user specifiable segments: %+v", err)
			}

			if len(*names) < 2 {
				return nil, fmt.Errorf("insufficient segments to create a unique identifier from %q", uri)
			}

			// /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/hostingEnvironments/{name}/workerPools/{workerPoolName}/instances/{instance}
			// /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/hostingEnvironments/{name}/multiRolePools/default/instances/{instance}
			childName := (*names)[len(*names)-1] + "Id"
			// the names must already conflict or we wouldn't be here
			parentName := (*names)[len(*names)-2]
			key := fmt.Sprintf("%s%s", normalizeSegmentName(parentName), normalizeSegmentName(childName))

			// check if we have an existing match for ParentChild
			if v, ok := keyHasConflicts(key, identifiers, proposed); ok && *v != uri {
				if len(*names) < 3 {
					return nil, fmt.Errorf("need a third unique identifier to make %q unique", uri)
				}

				// prefix the parent name
				if len(*names) >= 3 {
					grandparentName := (*names)[len(*names)-3]
					normalized := normalizeSegmentName(grandparentName)
					key = fmt.Sprintf("%s%s", normalized, key)

					if v, ok := keyHasConflicts(key, identifiers, proposed); ok {
						if *v != uri {
							// e.g. Web App Slots
							// /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/instances/{instanceId}/processes/{processId}/modules/{baseAddress}
							// /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/instances/{instanceId}/processes/{processId}/modules/{baseAddress}
							if len(*names) < 4 {
								return nil, fmt.Errorf("need a fourth unique identifier to make %q unique", uri)
							}

							// prefix the grandparent name
							if len(*names) >= 4 {
								grandparentName := (*names)[len(*names)-4]
								normalized := normalizeSegmentName(grandparentName)
								key = fmt.Sprintf("%s%s", normalized, key)

								if v, ok := keyHasConflicts(key, identifiers, proposed); ok {
									if *v != uri {
										return nil, fmt.Errorf("conflicting unique keys for %q - %q and %q conflict", key, *v, uri)
									}
								}
							}
						}
					}
				}
			}

			proposed[key] = uri
		}

		// at this point all of these must be unique, so let's add them to identifiers
		for k, v := range proposed {
			identifiers[k] = v
		}
	}
	return &identifiers, nil
}

func keyHasConflicts(key string, identifiers, proposed map[string]string) (*string, bool) {
	if v, ok := identifiers[key]; ok {
		return &v, true
	}
	if v, ok := proposed[key]; ok {
		return &v, true
	}

	return nil, false
}
