package resourceids

import "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"

type OperationResult struct {
	resourceId *models.ParsedResourceId

	// ResourceIdName is the name of the ResourceID
	ResourceIdName *string

	// UriSuffix is any Suffix which should be appended to the URI, if present.
	// This can either be specified with a ResourceIdName, when it's suffixed,
	// or can be standalone (e.g. this Operation is a static URI with no Resource ID).
	UriSuffix *string
}

// NormalizedUri returns the normalized URI for this operation
func (r OperationResult) NormalizedUri() string {
	return "/bob"
}

type ParseResult struct {
	// OriginalUrisToResourceIDs is a mapping of the original URI to a OperationResult object
	// which allows mapping the original URI to the Normalized Resource ID once processed.
	OriginalUrisToResourceIDs map[string]OperationResult

	// NamesToResourceIDs is a mapping of the ResourceID Names to the Parsed Resource ID objects
	NamesToResourceIDs map[string]models.ParsedResourceId

	// ResourceIDsToNames is a map of the NormalizedUri to the ResourceIdName
	ResourceIDsToNames map[string]string

	// Constants is a map of Name - ConstantDetails found within the Resource IDs
	Constants map[string]models.ConstantDetails
}
