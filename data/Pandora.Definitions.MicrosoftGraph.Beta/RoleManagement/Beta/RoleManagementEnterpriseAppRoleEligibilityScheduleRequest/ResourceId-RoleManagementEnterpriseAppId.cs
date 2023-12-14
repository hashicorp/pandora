// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.RoleManagement.Beta.RoleManagementEnterpriseAppRoleEligibilityScheduleRequest;

internal class RoleManagementEnterpriseAppId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/roleManagement/enterpriseApps/{rbacApplicationId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticRoleManagement", "roleManagement"),
        ResourceIDSegment.Static("staticEnterpriseApps", "enterpriseApps"),
        ResourceIDSegment.UserSpecified("rbacApplicationId")
    };
}
