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

var _ serviceWorkaround = workaroundEntitlementManagementRoleAssignment{}

// workaroundEntitlementManagementRoleAssignment supports an HTTP 200 response for the CreateEntitlementManagementRoleAssignment operation.
type workaroundEntitlementManagementRoleAssignment struct{}

func (workaroundEntitlementManagementRoleAssignment) Name() string {
	return "EntitlementManagementRoleAssignment / set correct response status codes"
}

func (workaroundEntitlementManagementRoleAssignment) Process(apiVersion, serviceName string, resources parser.Resources, resourceIds parser.ResourceIds) error {
	if apiVersion != versions.ApiVersionBeta {
		return nil
	}

	if serviceName != "roleManagement" {
		return nil
	}

	resource, ok := resources["RoleManagementEntitlementManagementRoleAssignment"]
	if !ok {
		return fmt.Errorf("`RoleManagementEntitlementManagementRoleAssignment` resource was not found for the `roleManagement` service")
	}

	for i := range resource.Operations {
		if resource.Operations[i].Name == "CreateEntitlementManagementRoleAssignment" {
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
