// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package workarounds

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/parser"
)

var _ dataWorkaround = workaroundCrossTenantAccessPolicyConfigurationPartner{}

// workaroundCrossTenantAccessPolicyConfigurationPartner adds missing fields and fixes some field types.
type workaroundCrossTenantAccessPolicyConfigurationPartner struct{}

func (workaroundCrossTenantAccessPolicyConfigurationPartner) Name() string {
	return "Cross Tenant Access Policy Configuration Partner / tenantId is not read-only"
}

func (workaroundCrossTenantAccessPolicyConfigurationPartner) Process(apiVersion string, models parser.Models, constants parser.Constants, resourceIds parser.ResourceIds) error {
	model, ok := models["microsoft.graph.crossTenantAccessPolicyConfigurationPartner"]
	if !ok {
		return fmt.Errorf("`crossTenantAccessPolicyConfigurationPartner` model not found")
	}

	// `tenantId` is not read-only
	if _, ok = model.Fields["tenantId"]; !ok {
		return fmt.Errorf("`tenantId` field not found")
	}
	model.Fields["tenantId"].ReadOnly = false

	return nil
}
