package featureflags

import (
	"os"
	"strings"
)

// GenerateNormalizationFunctionsForConstants specifies whether Normalization functions
// should be generated for Constants. This means that APIs which return Constants in a
// differing casing to those defined in the SDK will be automatically re-cased during
// deserialization if they match a defined value. For example `standard` -> `Standard`.
//
// Values which are unmatched (e.g. new/undefined values) will be left as-is and just
// unmarshalled as normal.
const GenerateNormalizationFunctionsForConstants = false

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
