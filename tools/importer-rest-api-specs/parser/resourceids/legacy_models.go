package resourceids

import (
	"fmt"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/parser/internal"
)

type ResourceIdParseResult struct {
	// NameToResourceIDs is a map[name]ParsedResourceID containing information about the Resource ID's
	NameToResourceIDs map[string]models.ParsedResourceId

	// NestedResult contains any constants and models found when parsing these ID's
	NestedResult internal.ParseResult

	// ResourceUriMetadata is a map[uri]ResourceUriMetadata for the Resource ID reference & any suffix
	ResourceUrisToMetadata map[string]ResourceUriMetadata
}

func (result *ResourceIdParseResult) Append(other ResourceIdParseResult) error {
	if err := result.NestedResult.Append(other.NestedResult); err != nil {
		return fmt.Errorf("appending other nestedResult: %+v", err)
	}

	out := make(map[string]ResourceUriMetadata)
	// intentional since this can be nil
	for k, v := range result.ResourceUrisToMetadata {
		out[k] = v
	}
	for k, v := range other.ResourceUrisToMetadata {
		if existingVal, existing := out[k]; existing {
			matches := false

			if v.ResourceId != nil && existingVal.ResourceId != nil && v.ResourceId.Matches(*existingVal.ResourceId) {
				matches = true
			}
			if v.UriSuffix != nil && existingVal.UriSuffix != nil && *v.UriSuffix == *existingVal.UriSuffix {
				matches = true
			}

			if matches {
				continue
			}
			return fmt.Errorf("conflicting Uris with the key %q (First %+v / Second %+v)", k, v, existingVal)
		}

		out[k] = v
	}
	result.ResourceUrisToMetadata = out

	return nil
}
