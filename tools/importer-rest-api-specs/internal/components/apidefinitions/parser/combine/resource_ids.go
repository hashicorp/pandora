// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package combine

import (
	"fmt"

	sdkHelpers "github.com/hashicorp/pandora/tools/data-api-sdk/v1/helpers"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/comparison"
)

func combineResourceIds(resourceIds, other map[string]sdkModels.ResourceID) error {
	for k, v := range other {
		// if there's duplicate Resource IDs named the same in different Swaggers, this is likely a data issue
		resourceId, ok := resourceIds[k]
		if ok && !comparison.ResourceIDsMatch(v, resourceId) {
			return fmt.Errorf("duplicate Resource ID named %q (First %q / Second %q)", k, sdkHelpers.DisplayValueForResourceID(v), sdkHelpers.DisplayValueForResourceID(resourceId))
		}

		resourceIds[k] = v
	}

	return nil
}
