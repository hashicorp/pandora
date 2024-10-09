package cleanup

import (
	"strings"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
)

func SimplifyOperationNamesForAPIResource(apiResourceName string, apiResource sdkModels.APIResource) sdkModels.APIResource {
	allOperationsStartWithPrefix := true
	resourceNameLower := strings.ToLower(apiResourceName)
	for operationName := range apiResource.Operations {
		operationNameLowered := strings.ToLower(operationName)
		if !strings.HasPrefix(operationNameLowered, resourceNameLower) || strings.EqualFold(operationNameLowered, resourceNameLower) {
			allOperationsStartWithPrefix = false
			break
		}
	}

	if !allOperationsStartWithPrefix {
		logging.Tracef("Skipping simplifying operation names for resource %q", apiResourceName)
		return apiResource
	}

	output := make(map[string]sdkModels.SDKOperation)
	for key, value := range apiResource.Operations {
		updatedKey := key[len(resourceNameLower):]
		// Trim off any spurious `s` at the start. This happens when the Swagger Tag and the Operation ID
		// use different pluralizations (e.g. one is Singular and the other is Plural)
		//
		// Whilst it's possible this could happen for other suffixes (e.g. `ies`, or `y`)
		// the Data only shows `s` at this point in time, so this is sufficient for now:
		// https://github.com/hashicorp/pandora/pull/3016#pullrequestreview-1612987765
		//
		// Any other examples will generate successfully but be unusable in the Go SDK since these
		// will be treated as unexported methods - and can be addressed then.
		if strings.HasPrefix(updatedKey, "s") {
			updatedKey = updatedKey[1:]
		}

		logging.Tracef("Simplifying Operation %q to %q", key, updatedKey)
		output[updatedKey] = value
	}

	apiResource.Operations = output
	return apiResource
}
