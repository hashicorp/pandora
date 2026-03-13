// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package workarounds

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/parser"
)

var _ dataWorkaround = workaroundUnifiedRoleManagementPolicy{}

// workaroundUnifiedRoleManagementPolicy adds missing fields and fixes some field types.
type workaroundUnifiedRoleManagementPolicy struct{}

func (workaroundUnifiedRoleManagementPolicy) Name() string {
	return "Unified Role Management Policy / lastModifiedBy and lastModifiedDateTime are read-only"
}

func (workaroundUnifiedRoleManagementPolicy) Process(apiVersion string, models parser.Models, constants parser.Constants, resourceIds parser.ResourceIds) error {
	model, ok := models["microsoft.graph.unifiedRoleManagementPolicy"]
	if !ok {
		return fmt.Errorf("`unifiedRoleManagementPolicy` model not found")
	}

	// `lastModifiedBy` is read-only
	if _, ok = model.Fields["lastModifiedBy"]; !ok {
		return fmt.Errorf("`lastModifiedBy` field not found")
	}
	model.Fields["lastModifiedBy"].ReadOnly = true

	// `lastModifiedDateTime` is read-only
	if _, ok = model.Fields["lastModifiedDateTime"]; !ok {
		return fmt.Errorf("`lastModifiedDateTime` field not found")
	}
	model.Fields["lastModifiedDateTime"].ReadOnly = true

	return nil
}
