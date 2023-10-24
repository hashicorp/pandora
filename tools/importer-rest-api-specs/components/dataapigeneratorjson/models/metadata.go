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

type ApiDefinitionsSource string

const (
	// AzureRestApiSpecsRepositoryApiDefinitionsSource specifies that the source data came from
	// the Azure Rest API Specs repository at github.com/Azure/azure-rest-api-specs
	AzureRestApiSpecsRepositoryApiDefinitionsSource ApiDefinitionsSource = "Azure/azure-rest-api-specs"

	// MicrosoftGraphMetaDataRepositoryApiDefinitionsSource specifies that the source data came from
	// the Microsoft Graph MetaData repository at github.com/microsoftgraph/msgraph-metadata
	MicrosoftGraphMetaDataRepositoryApiDefinitionsSource ApiDefinitionsSource = "microsoftgraph/msgraph-metadata"

	// HandWrittenApiDefinitionsSource specifies that these API definitions were written by hand and
	// not generated from an OpenAPI/Swagger definition.
	HandWrittenApiDefinitionsSource ApiDefinitionsSource = "handwritten"
)
