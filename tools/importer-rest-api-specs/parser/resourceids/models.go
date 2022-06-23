package resourceids

import "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"

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
	// OriginalUrisToResourceIDs is a mapping of the original URI to a ParsedOperation object
	// which allows mapping the original URI to the Normalized Resource ID once processed.
	OriginalUrisToResourceIDs map[string]ParsedOperation

	// NamesToResourceIDs is a mapping of the ResourceID Names to the Parsed Resource ID objects
	NamesToResourceIDs map[string]models.ParsedResourceId

	// Constants is a map of Name - ConstantDetails found within the Resource IDs
	Constants map[string]models.ConstantDetails
}

func (r *ParseResult) Append(other ParseResult) error {
	// TODO: implement me
	return nil
}
