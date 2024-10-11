// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package workarounds

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/parser"
)

var _ dataWorkaround = workaroundUnifiedRoleAssignment{}

// workaroundUnifiedRoleAssignment adds missing fields and fixes some field types.
type workaroundUnifiedRoleAssignment struct{}

func (workaroundUnifiedRoleAssignment) Name() string {
	return "Unified Role Assignment / roleDefinitionId is not read-only"
}

func (workaroundUnifiedRoleAssignment) Process(apiVersion string, models parser.Models, constants parser.Constants, resourceIds parser.ResourceIds) error {
	model, ok := models["microsoft.graph.unifiedRoleAssignment"]
	if !ok {
		return fmt.Errorf("`unifiedRoleAssignment` model not found")
	}

	// `roleDefinitionId` is not read-only
	if _, ok = model.Fields["roleDefinitionId"]; !ok {
		return fmt.Errorf("`roleDefinitionId` field not found")
	}
	model.Fields["roleDefinitionId"].ReadOnly = false

	return nil
}
