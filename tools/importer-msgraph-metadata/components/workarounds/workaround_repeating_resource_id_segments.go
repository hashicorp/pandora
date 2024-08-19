// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package workarounds

import (
	"strings"

	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/parser"
)

var _ workaround = workaroundRepeatingResourceIdSegments{}

// workaroundRepeatingResourceIdSegments removes incompatible resource IDs due to repeating segments which are not supported at this time.
type workaroundRepeatingResourceIdSegments struct{}

func (workaroundRepeatingResourceIdSegments) Name() string {
	return "Resource IDs with repeating segments / remove incompatible resource IDs"
}

func (workaroundRepeatingResourceIdSegments) Process(apiVersion string, models parser.Models, constants parser.Constants, resourceIds parser.ResourceIds) error {
	for resourceIdName := range resourceIds {
		var invalid bool

		// Repeating segments, which are not supported
		if strings.Contains(resourceIdName, "SiteIdSiteId") {
			invalid = true
		}

		// GroupSiteTermStore resources have repeating ID segments which are not supported at this time
		if strings.Contains(resourceIdName, "TermStore") {
			invalid = true
		}

		// Onenote resources have repeating ID segments which are not supported at this time
		if strings.Contains(resourceIdName, "Onenote") {
			invalid = true
		}

		// These contain IDs with repeating segments, which are not supported at this time
		prefixes := []string{
			"IdentityGovernanceEntitlementManagementAccessPackageIdResourceRoleScopeIdRoleResourceScopeIdResourceRoleId",
			"IdentityGovernanceEntitlementManagementAccessPackageIdResourceRoleScopeIdScopeResourceRoleIdResourceScopeId",
			"IdentityGovernanceEntitlementManagementCatalogIdResourceRoleIdResourceScopeIdResourceRoleId",
			"IdentityGovernanceEntitlementManagementCatalogIdResourceScopeIdResourceRoleIdResourceScopeId",
			"IdentityGovernanceEntitlementManagementResourceRequestIdCatalogResourceRoleIdResourceScopeIdResourceRoleId",
			"IdentityGovernanceEntitlementManagementResourceRequestIdCatalogResourceScopeIdResourceRoleIdResourceScopeId",
			"IdentityGovernanceEntitlementManagementResourceRequestIdResourceRoleIdResourceScopeId",
			"IdentityGovernanceEntitlementManagementResourceRequestIdResourceScopeIdResourceRoleId",
			"IdentityGovernanceEntitlementManagementResourceRoleScopeIdRoleResourceScopeIdResourceRoleId",
			"IdentityGovernanceEntitlementManagementResourceRoleScopeIdScopeResourceRoleIdResourceScopeId",
			"MePendingAccessReviewInstanceIdDecisionIdInstanceStageIdDecisionId",
			"MePendingAccessReviewInstanceIdDecisionIdInstanceStageIdDecisionIdInsightId",
			"MePendingAccessReviewInstanceIdStageIdDecisionIdInstanceDecisionId",
			"MePendingAccessReviewInstanceIdStageIdDecisionIdInstanceDecisionIdInsightId",
			"UserIdPendingAccessReviewInstanceIdDecisionIdInstanceStageIdDecisionId",
			"UserIdPendingAccessReviewInstanceIdDecisionIdInstanceStageIdDecisionIdInsightId",
			"UserIdPendingAccessReviewInstanceIdStageIdDecisionIdInstanceDecisionId",
			"UserIdPendingAccessReviewInstanceIdStageIdDecisionIdInstanceDecisionIdInsightId",
		}
		for _, prefix := range prefixes {
			if strings.HasPrefix(resourceIdName, prefix) {
				invalid = true
			}
		}

		if invalid {
			delete(resourceIds, resourceIdName)
		}
	}

	return nil
}
