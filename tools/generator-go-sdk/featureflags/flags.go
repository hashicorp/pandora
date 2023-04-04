package featureflags

import (
	"os"
	"strings"
)

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
