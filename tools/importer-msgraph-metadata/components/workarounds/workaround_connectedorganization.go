// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package workarounds

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/parser"
)

var _ dataWorkaround = workaroundConnectedOrganization{}

// workaroundConnectedOrganization adds missing fields and fixes some field types.
type workaroundConnectedOrganization struct{}

func (workaroundConnectedOrganization) Name() string {
	return "Connected Organization / identitySources is not read-only"
}

func (workaroundConnectedOrganization) Process(apiVersion string, models parser.Models, constants parser.Constants, resourceIds parser.ResourceIds) error {
	model, ok := models["microsoft.graph.connectedOrganization"]
	if !ok {
		return fmt.Errorf("`connectedOrganization` model not found")
	}

	// `identitySources` is not read-only
	if _, ok = model.Fields["identitySources"]; !ok {
		return fmt.Errorf("`identitySources` field not found")
	}
	model.Fields["identitySources"].ReadOnly = false

	return nil
}
