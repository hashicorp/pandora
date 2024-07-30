package blacklisted

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/parser"
)

func Resource(resource *parser.Resource) bool {
	if resource.Service == "Groups" {

		// Repeating ID segments which are not supported
		if resource.Name == "SiteSite" {
			return true
		}

		// GroupSiteTermStore resources have repeating ID segments which are not supported at this time
		if strings.Contains(resource.Name, "TermStore") {
			return true
		}

		// Onenote resources have repeating ID segments which are not supported at this time
		if strings.Contains(resource.Name, "Onenote") {
			return true
		}

	}

	if resource.Service == "IdentityGovernance" {

		// Repeating ID segments which are not supported at this time
		prefixes := []string{
			"EntitlementManagementAccessPackageResourceRoleScopeRoleResourceScopeResourceRole",
			"EntitlementManagementAccessPackageResourceRoleScopeScopeResourceRoleResourceScope",
			"EntitlementManagementCatalogResourceRoleResourceScopeResourceRole",
			"EntitlementManagementCatalogResourceScopeResourceRoleResourceScope",
			"EntitlementManagementResourceRequestCatalogResourceRoleResourceScopeResource",
			"EntitlementManagementResourceRequestCatalogResourceScopeResourceRoleResourceScope",
			"EntitlementManagementResourceRequestResourceRoleResourceScope",
			"EntitlementManagementResourceRequestResourceScopeResourceRole",
			"EntitlementManagementResourceRoleScopeRoleResourceScopeResourceRole",
			"EntitlementManagementResourceRoleScopeScopeResourceRoleResourceScope",
		}
		for _, prefix := range prefixes {
			if strings.HasPrefix(resource.Name, prefix) || strings.HasPrefix(resource.Name, fmt.Sprintf("%s%s", resource.Service, prefix)) {
				return true
			}
		}

	}

	if resource.Service == "Me" || resource.Service == "Users" {

		// Onenote resources have repeating ID segments which are not supported at this time
		if strings.Contains(resource.Name, "Onenote") {
			return true
		}

		// Repeating ID segments which are not supported at this time
		prefixes := []string{
			"PendingAccessReviewInstanceDecisionInstanceStageDecision",
			"PendingAccessReviewInstanceStageDecisionInstanceDecision",
		}
		for _, prefix := range prefixes {
			if strings.HasPrefix(resource.Name, prefix) || strings.HasPrefix(resource.Name, fmt.Sprintf("%s%s", resource.Service, prefix)) {
				return true
			}
		}

	}

	return false
}
