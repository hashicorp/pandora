// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package models

// MetaData contains Meta Data about this
type MetaData struct {
	// DataSource specifies the type of Data that this Source is related to
	// for example `AzureResourceManager`. This allows multiple directories
	// to be used to populate the same Data Source (for example, auto-generated
	// and handwritten) and then coalesced together.
	DataSource DataSource `json:"dataSource"`

	// SourceInformation specifies where the data within this directory was sourced.
	SourceInformation ApiDefinitionsSource `json:"sourceInformation"`

	// GitRevision specified the Git Revision (SHA) of the Repository
	// where this data has been sourced from.
	// This is either going to be the SHA of the `Azure/azure-rest-api-specs` repository (for ARM),
	// the `microsoftgraph/msgraph-metadata` repository (for MS Graph) - or null (for handwritten).
	GitRevision *string `json:"gitRevision"`
}

type DataSource string

const (
	// AzureResourceManagerDataSource specifies that this Data is related to Azure Resource Manager.
	AzureResourceManagerDataSource DataSource = "AzureResourceManager"

	// MicrosoftGraphDataSource specifies that this Data is for Microsoft Graph.
	MicrosoftGraphDataSource DataSource = "MicrosoftGraph"
)

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
	HandWrittenApiDefinitionsSource ApiDefinitionsSource = "HandWritten"
)
