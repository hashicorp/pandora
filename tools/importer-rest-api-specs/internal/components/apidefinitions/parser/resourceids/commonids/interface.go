// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package commonids

import sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"

type commonIdMatcher interface {
	// ID returns the Resource ID for this Common ID
	ID() sdkModels.ResourceID
}
