package resourceids

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/internal"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

type ParsedOperation struct {
	// ResourceId is the ParsedResourceId object for this Resource Id
	ResourceId *models.ParsedResourceId

	// ResourceIdName is the name of the ResourceID
	ResourceIdName *string

	// UriSuffix is any Suffix which should be appended to the URI, if present.
	// This can either be specified with a ResourceIdName, when it's suffixed,
	// or can be standalone (e.g. this Operation is a static URI with no Resource ID).
	UriSuffix *string
}

type ParseResult struct {
	// OperationIdsToParsedResourceIds is a map of the original Operation IDs to the ParsedOperation
	// object containing the parsed Resource ID.
	OperationIdsToParsedResourceIds map[string]ParsedOperation

	//// OriginalUrisToResourceIDs is a mapping of the original URI to a ParsedOperation object
	//// which allows mapping the original URI to the Normalized Resource ID once processed.
	//OriginalUrisToResourceIDs map[string]ParsedOperation

	// NamesToResourceIDs is a mapping of the ResourceID Names to the Parsed Resource ID objects
	NamesToResourceIDs map[string]models.ParsedResourceId

	// Constants is a map of Name - ConstantDetails found within the Resource IDs
	Constants map[string]resourcemanager.ConstantDetails
}

func (r *ParseResult) Append(other ParseResult, logger hclog.Logger) error {
	intermediate := internal.ParseResult{
		Constants: map[string]resourcemanager.ConstantDetails{},
	}
	intermediate.AppendConstants(r.Constants)
	intermediate.AppendConstants(other.Constants)
	r.Constants = intermediate.Constants

	operationIdsToParsedOperations := make(map[string]ParsedOperation)
	// intentional since this can be nil
	for k, v := range r.OperationIdsToParsedResourceIds {
		operationIdsToParsedOperations[k] = v
	}
	if len(other.OperationIdsToParsedResourceIds) > 0 {
		// first concat the other uris

		for k, v := range other.OperationIdsToParsedResourceIds {
			if existingVal, existing := operationIdsToParsedOperations[k]; existing {
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

			operationIdsToParsedOperations[k] = v
		}
		r.OperationIdsToParsedResourceIds = operationIdsToParsedOperations

		// since we have a new list of Resource IDs we also need to go through and regenerate the names
		// as we may have conflicts etc
		combinedResourceIds := make([]models.ParsedResourceId, 0)
		for _, v := range r.NamesToResourceIDs {
			combinedResourceIds = append(combinedResourceIds, v)
		}
		for _, v := range other.NamesToResourceIDs {
			foundMatching := false
			for _, otherId := range combinedResourceIds {
				if v.Matches(otherId) {
					foundMatching = true
					break
				}
			}
			if !foundMatching {
				combinedResourceIds = append(combinedResourceIds, v)
			}
		}

		// this may cause rename for name conflict, so have to modify the name in OriginalUrisToResourceIDs too
		namesToResourceIds, err := generateNamesForResourceIds(combinedResourceIds, r.OperationIdsToParsedResourceIds)
		if err != nil {
			return fmt.Errorf("regenerating Names : Resource IDs for combined list: %+v", err)
		}
		r.NamesToResourceIDs = *namesToResourceIds
	}

	return nil
}
