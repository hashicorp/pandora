// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package models

// APIResource defines a grouping of related information within an APIVersion.
type APIResource struct {
	// Constants specifies a map of Constant Name (key) to SDKConstant (value)
	// which contains information about the Constants used within this APIResource.
	// NOTE: the Constant Name is a valid Identifier.
	Constants map[string]SDKConstant

	// Models specifies a map of Model Name (key) to SDKModel (value)
	// which contains information about the Models used within this APIResource.
	// NOTE: the Model Name is a valid Identifier.
	Models map[string]SDKModel

	// Name specifies the name of this APIResource.
	Name string

	// Operations specifies a map of Operation Name (key) to SDKOperation (value)
	// which contains information about the Operations used within this APIResource.
	// NOTE: the Operation Name is a valid Identifier.
	Operations map[string]SDKOperation

	// ResourceIDs specifies a map of Resource ID Name (key) to SDKOperation (value)
	// which contains information about the ResourceIDs used within this APIResource.
	// NOTE: the Resource ID Name is a valid Identifier.
	ResourceIDs map[string]ResourceID
}
