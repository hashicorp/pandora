// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package models

// SDKDateFormat defines the required format for a DateTime value.
// whilst in the majority of cases this is going to be an RFC3339 value
// (specified by RFC3339SDKDateFormat) - multiple other types are possible
// however are unimplemented at this time.
// Related: https://github.com/hashicorp/pandora/issues/8
type SDKDateFormat = string

const (
	// RFC3339SDKDateFormat specifies that the DateTime is an RFC3339 value.
	RFC3339SDKDateFormat SDKDateFormat = "RFC3339"

	// RFC3339NanoSDKDateFormat specifies that the DateTime is an RFC3339Nano value.
	RFC3339NanoSDKDateFormat SDKDateFormat = "RFC3339Nano"
)
