// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ commonIdMatcher = commonIdScopeMatcher{}

type commonIdScopeMatcher struct{}

func (commonIdScopeMatcher) id() sdkModels.ResourceID {
	name := "Scope"
	return sdkModels.ResourceID{
		CommonIDAlias: &name,
		ConstantNames: []string{},
		Segments: []sdkModels.ResourceIDSegment{
			sdkModels.NewScopeResourceIDSegment("scope"),
		},
	}
}
