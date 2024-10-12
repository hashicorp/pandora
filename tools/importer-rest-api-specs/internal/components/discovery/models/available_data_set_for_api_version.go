// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package models

// AvailableDataSetForAPIVersion defines the set of data related to a specific API Version
// This information is used by the Parser to parse out the information for this Service/API Version combination.
//
// NOTE: in the future we could likely extend the Discovery logic to build and return an instance of
// AvailableDataSetForAPIVersion from the TypeSpec files, too.
type AvailableDataSetForAPIVersion struct {
	// APIVersion specifies the APIVersion which this DataSet is related to.
	APIVersion string

	// ContainsStableAPIVersion specifies whether this is considered a Stable API Version or not.
	// if not, this should be considered a Preview API Version (either Private/Public Preview, or similar).
	ContainsStableAPIVersion bool

	// FilePathsContainingAPIDefinitions is a slice of the absolute file paths which contain the APIDefinitions
	// for the Service/API Version combination.
	FilePathsContainingAPIDefinitions []string
}
