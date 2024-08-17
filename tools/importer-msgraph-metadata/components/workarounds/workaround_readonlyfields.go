// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package workarounds

import (
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/parser"
)

var _ workaround = workaroundReadOnlyFields{}

// workaroundReadOnlyFields ensures all common readonly fields are marked as such - unfortunately the spec
// does not mark these as ReadOnly.
type workaroundReadOnlyFields struct{}

func (workaroundReadOnlyFields) Name() string {
	return "Read-Only Fields / override common readonly fields"
}

func (workaroundReadOnlyFields) Process(apiVersion string, models parser.Models, constants parser.Constants) error {
	for _, model := range models {
		if _, ok := model.Fields["CreatedOnBehalfOf"]; ok {
			model.Fields["CreatedOnBehalfOf"].ReadOnly = true
		}
	}

	return nil
}
