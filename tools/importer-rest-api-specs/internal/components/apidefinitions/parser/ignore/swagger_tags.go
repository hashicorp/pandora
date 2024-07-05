package ignore

import "strings"

var swaggerTagsToIgnore = map[string]struct{}{
	"azurefirewallfqdntags": {},
	"usage":                 {},
}

func SwaggerTag(tag string) bool {
	lowered := strings.ToLower(tag)
	for key := range swaggerTagsToIgnore {
		// exact matches e.g. Usage
		if strings.EqualFold(tag, key) {
			return true
		}

		// suffixes e.g. `ComputeUsage`
		if strings.HasSuffix(lowered, strings.ToLower(key)) {
			return true
		}
	}

	// there's a handful of these (e.g. `FluxConfigurationOperationStatus`)
	if strings.Contains(lowered, "operationstatus") {
		return true
	}

	return false
}
