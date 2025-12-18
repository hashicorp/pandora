// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package models

// SourceDataOrigin defines where a given set of Source Data (associated with a SourceDataType)
// came from - both for informational purposes and for licence attribution as needed.
type SourceDataOrigin = string

const (
	// AzureRestAPISpecsSourceDataOrigin specifies that the Source Data comes from the
	// Azure Rest API Specs repository at `github.com/Azure/azure-rest-api-specs`.
	AzureRestAPISpecsSourceDataOrigin SourceDataOrigin = "ResourceManagerRestApiSpecs"

	// MicrosoftGraphMetaDataSourceDataOrigin specifies that the Source Data comes from the
	// Microsoft Graph MetaData repository at `github.com/microsoftgraph/msgraph-metadata`.
	MicrosoftGraphMetaDataSourceDataOrigin SourceDataOrigin = "MicrosoftGraphMetadata"

	// HandWrittenSourceDataOrigin specifies that this data was written by hand.
	HandWrittenSourceDataOrigin SourceDataOrigin = "HandWritten"
)
