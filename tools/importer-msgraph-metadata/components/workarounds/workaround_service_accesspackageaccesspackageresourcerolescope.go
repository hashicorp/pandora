// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package workarounds

import (
	"fmt"
	"slices"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/parser"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/versions"
)

var _ serviceWorkaround = workaroundEntitlementManagementAccessPackageAccessPackageResourceRoleScope{}

// workaroundEntitlementManagementAccessPackageAccessPackageResourceRoleScope supports an HTTP 200 response for the DeleteEntitlementManagementAccessPackageResourceRoleScope operation.
type workaroundEntitlementManagementAccessPackageAccessPackageResourceRoleScope struct{}

func (workaroundEntitlementManagementAccessPackageAccessPackageResourceRoleScope) Name() string {
	return "EntitlementManagementAccessPackageAccessPackageResourceRoleScope / set correct response status codes"
}

func (workaroundEntitlementManagementAccessPackageAccessPackageResourceRoleScope) Process(apiVersion, serviceName string, resources parser.Resources, resourceIds parser.ResourceIds) error {
	if apiVersion != versions.ApiVersionBeta {
		return nil
	}

	if serviceName != "identityGovernance" {
		return nil
	}

	resource, ok := resources["IdentityGovernanceEntitlementManagementAccessPackageAccessPackageResourceRoleScope"]
	if !ok {
		return fmt.Errorf("`IdentityGovernanceEntitlementManagementAccessPackageAccessPackageResourceRoleScope` resource was not found for the `identityGovernance` service")
	}

	for i := range resource.Operations {
		if resource.Operations[i].Name == "DeleteEntitlementManagementAccessPackageResourceRoleScope" {
			statusesFromSpec := make([]int, 0, len(resource.Operations[i].Responses))
			for j := range resource.Operations[i].Responses {
				statusesFromSpec = append(statusesFromSpec, resource.Operations[i].Responses[j].Status)
			}

			if !slices.Contains(statusesFromSpec, 200) {
				resource.Operations[i].Responses = append(resource.Operations[i].Responses, parser.Response{
					Status:      200,
					ContentType: pointer.To("application/json"),
				})
			}
			break
		}
	}

	return nil
}
