// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ commonIdMatcher = commonIdScopeMatcher{}

type commonIdScopeMatcher struct{}

func (commonIdScopeMatcher) id() models.ResourceID {
	name := "Scope"
	return models.ResourceID{
		CommonIDAlias: &name,
		ConstantNames: []string{},
		Segments: []models.ResourceIDSegment{
			models.NewScopeResourceIDSegment("scope"),
		},
	}
}
