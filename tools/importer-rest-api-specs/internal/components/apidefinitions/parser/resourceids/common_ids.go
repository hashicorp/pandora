// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	sdkHelpers "github.com/hashicorp/pandora/tools/data-api-sdk/v1/helpers"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/comparison"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/resourceids/commonids"
)

func switchOutCommonResourceIDsAsNeeded(input []sdkModels.ResourceID) []sdkModels.ResourceID {
	output := make([]sdkModels.ResourceID, 0)

	for _, value := range input {
		// TODO: we should expose a `[]CommonIDs` function from `hashicorp/go-azure-helpers` so that we can reuse these
		// the types (intentionally) don't align but we have enough information here to map the data across
		for _, commonId := range commonids.CommonIDTypes {
			if comparison.ResourceIDsMatch(commonId.ID(), value) {
				value = commonId.ID()
				value.ExampleValue = sdkHelpers.DisplayValueForResourceID(value)
				break
			}
		}

		output = append(output, value)
	}

	return output
}
