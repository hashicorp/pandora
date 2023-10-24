package models

// MetaData contains Meta Data about this
type MetaData struct {
	// TODO: the license information could make sense to go in here, since all items within a
	// directory should be under the same license

	// GitRevision specified the Git Revision (SHA) of the Repository
	// where this data has been sourced from.
	// This is either going to be the SHA of the `Azure/azure-rest-api-specs` repository (for ARM),
	// the `microsoftgraph/msgraph-metadata` repository (for MS Graph) - or null (for handwritten).
	GitRevision *string `json:"gitRevision"`
}
