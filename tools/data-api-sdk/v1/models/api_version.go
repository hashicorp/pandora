// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package models

// APIVersion defines a version of an API for a specific Service.
// An example of this would be `2021-01-01` (within the Service `Compute`)
// which contains APIResource's for `ManagedDisks` and `VirtualMachines`.
type APIVersion struct {
	// APIVersion specifies the Version of this API.
	APIVersion string

	// Generate specifies whether this APIVersion should be generated or not.
	Generate bool

	// Preview specifies whether this APIVersion is a Preview API Version (meaning
	// `preview`, `publicpreview`, `privatepreview`, `beta` and `alpha`) as opposed
	// to a Stable API Version.
	Preview bool

	// Resources specifies a map of API Resource Names (key) to APIResource (value).
	// The API Resource Name is a valid Identifier.
	Resources map[string]APIResource

	// Source specifies the origin of the Source Data for this APIVersion.
	Source SourceDataOrigin
}
