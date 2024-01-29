// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package featureflags

import (
	"os"
	"strings"
)

// OptionalDiscriminatorsShouldBeOutputWithoutOmitEmpty specifies whether a field which contains
// a Discriminated Type that's Optional should be output as Optional without `omitempty` in the
// JSON Tags - this means that we'll send a `null` value rather than omitting it.
const OptionalDiscriminatorsShouldBeOutputWithoutOmitEmpty = false

// GenerateCaseInsensitiveFunctions specifies whether case-insensitive Resource ID parsing
// functions should be generated.
const GenerateCaseInsensitiveFunctions = true

// SkipDiscriminatedParentTypes returns whether or not the feature for skipping generation of
// discriminated parent types is enabled.
func SkipDiscriminatedParentTypes() bool {
	value := os.Getenv("PANDORA_SKIP_DISCRIMINATED_PARENT_TYPE")
	if value == "" {
		return true
	}

	return strings.EqualFold(value, "true")
}
