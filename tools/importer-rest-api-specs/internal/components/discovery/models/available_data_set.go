// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package models

// AvailableDataSet defines the available Data Sets for a Service - including the API Definitions
// for each API Version and any additional files.
type AvailableDataSet struct {
	// ServiceName is the name of the Service (e.g. `Compute`).
	ServiceName string

	// DataSetsForAPIVersions contains a map of API Version (key) to AvailableDataSetForAPIVersion (value)
	// which outlines the available Data Set for this API Version.
	DataSetsForAPIVersions map[string]AvailableDataSetForAPIVersion

	// ResourceProvider is the Resource Provider associated with this Data Set.
	ResourceProvider *string
}
