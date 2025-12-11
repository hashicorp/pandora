// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package workarounds

import (
	"fmt"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/versions"

	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/parser"
)

var _ dataWorkaround = workaroundAccessPackageResourceRoleScope{}

// workaroundAccessPackageResourceRoleScope adds missing fields and fixes some field types.
type workaroundAccessPackageResourceRoleScope struct{}

func (workaroundAccessPackageResourceRoleScope) Name() string {
	return "AccessPackageResourceRoleScope / accessPackageResourceRole & accessPackageResourceScope is not read-only"
}

func (workaroundAccessPackageResourceRoleScope) Process(apiVersion string, models parser.Models, constants parser.Constants, resourceIds parser.ResourceIds) error {
	if apiVersion != versions.ApiVersionBeta {
		return nil
	}

	model, ok := models["microsoft.graph.accessPackageResourceRoleScope"]
	if !ok {
		return fmt.Errorf("`accessPackageResourceRoleScope` model not found")
	}

	// `accessPackageResourceRole` is not read-only
	if _, ok = model.Fields["accessPackageResourceRole"]; !ok {
		return fmt.Errorf("`accessPackageResourceRole` field not found")
	}
	model.Fields["accessPackageResourceRole"].ReadOnly = false

	// `accessPackageResourceScope` is not read-only
	if _, ok = model.Fields["accessPackageResourceScope"]; !ok {
		return fmt.Errorf("`accessPackageResourceScope` field not found")
	}
	model.Fields["accessPackageResourceScope"].ReadOnly = false

	return nil
}
