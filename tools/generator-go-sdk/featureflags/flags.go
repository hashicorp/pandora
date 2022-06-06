package featureflags

import (
	"os"
	"strings"
)

const GenerateCaseInsensitiveFunctions = true

// SkipDiscriminatedParentTypes returns whether or not the feature for skipping generation of
// discriminated parent types is enabled.
func SkipDiscriminatedParentTypes() bool {
	value := os.Getenv("PANDORA_SKIP_DISCRIMINATED_PARENT_TYPE")
	if value == "" {
		return false
	}

	return strings.EqualFold(value, "true")
}
