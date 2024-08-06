package blacklisted

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/parser"
)

func Resource(resource *parser.Resource) bool {
	if resource.Service == "Groups" {

		// Has IDs with repeating segments, which are not supported
		if resource.Category == "SiteSite" {
			return true
		}

		// GroupSiteTermStore resources have repeating ID segments which are not supported at this time
		if strings.Contains(resource.Category, "TermStore") {
			return true
		}

		// Onenote resources have repeating ID segments which are not supported at this time
		if strings.Contains(resource.Category, "Onenote") {
			return true
		}

	}

	if resource.Service == "IdentityGovernance" {

		// These contain IDs with repeating segments, which are not supported at this time
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
			if strings.HasPrefix(resource.Category, prefix) || strings.HasPrefix(resource.Category, fmt.Sprintf("%s%s", resource.Service, prefix)) {
				return true
			}
		}

	}

	if resource.Service == "Me" || resource.Service == "Users" {

		// Onenote resources have repeating ID segments which are not supported at this time
		if strings.Contains(resource.Category, "Onenote") {
			return true
		}

		// These contain IDs with repeating segments, which are not supported at this time
		prefixes := []string{
			"PendingAccessReviewInstanceDecisionInstanceStageDecision",
			"PendingAccessReviewInstanceStageDecisionInstanceDecision",
		}
		for _, prefix := range prefixes {
			if strings.HasPrefix(resource.Category, prefix) || strings.HasPrefix(resource.Category, fmt.Sprintf("%s%s", resource.Service, prefix)) {
				return true
			}
		}

	}

	return false
}
