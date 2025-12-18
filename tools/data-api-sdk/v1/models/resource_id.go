// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package models

// ResourceID defines a Unique Resource Identifier.
// A ResourceID contains one or more ResourceIDSegment's which defines the shape of
// the expected ResourceID - and (SHOULD) typically contain an equal number of
// ResourceIDSegment's.
type ResourceID struct {
	// CommonIDAlias specifies the Common ID Alias for this Resource ID.
	// Common IDs are defined within `github.com/hashicorp/go-azure-helpers` and allow referencing
	// a single instance of a Resource ID type - rather than redefining this in multiple places.
	// Examples a Common ID include a Resource Group ID and a Subscription ID.
	CommonIDAlias *string `json:"commonAlias,omitempty"` // TODO: update the json struct tag when everything is switched over

	// ConstantNames specifies a list of Constant Names used within Segments.
	ConstantNames []string `json:"constantNames"` // TODO: remove this once everything is switched over

	// Constants specifies a map of Constant Name (Key) to SDKConstant (value) describing the Constants
	// used within Segments.
	// Note: the Constant Name is a valid Identifier.
	Constants map[string]SDKConstant `json:"constants"`

	// ExampleValue specifies a full example value for this ResourceID.
	// This is intended to be used in both documentation and error messages, so should be both
	// clear, short yet descriptive.
	// Example: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`
	ExampleValue string `json:"id"` // TODO: update the json struct tag when everything is switched over

	// Segments specifies the ResourceIDSegments which comprise this ResourceID.
	// At least one ResourceIDSegment must be specified - but typically a Resource ID contains
	// at least a StaticResourceIDSegmentType and a UserSpecifiedResourceIDSegmentType.
	Segments []ResourceIDSegment `json:"segments"`
}
