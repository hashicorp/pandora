// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package comparison

import (
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
)

func OperationOptionsMatch(first, second map[string]sdkModels.SDKOperationOption) bool {
	if len(first) != len(second) {
		logging.Tracef("Differing number of Options - %d vs %d", len(first), len(second))
		return false
	}

	for key, firstVal := range first {
		secondVal, ok := second[key]
		if !ok {
			logging.Tracef("Option %q was present in First but not Second", key)
			return false
		}

		if !OperationOptionMatch(firstVal, secondVal) {
			logging.Tracef("Option %q differed between First and Second. First: %+v. Second: %+v", key, firstVal, secondVal)
			return false
		}
	}

	return true
}
