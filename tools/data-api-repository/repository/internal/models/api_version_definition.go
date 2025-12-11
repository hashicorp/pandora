// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package models

// ApiVersionDefinition specifies an API Version within a Service which must contain at least one Resource
type ApiVersionDefinition struct {
	// ApiVersion specifies the Version Number for this API.
	// Example: `2020-01-01-preview`.
	ApiVersion string `json:"apiVersion"`

	// IsPreview specifies whether this is a Preview API version (otherwise it's a Stable API version).
	IsPreview bool `json:"isPreview"`

	// Generate specifies whether this API Version should be generated or not.
	Generate bool `json:"generate"`

	// Resources specifies a list of Api Resource names that exist within this API version.
	Resources []string `json:"resources"`

	// Source specifies where the definitions originated from
	Source ApiDefinitionsSource `json:"source"`
}
