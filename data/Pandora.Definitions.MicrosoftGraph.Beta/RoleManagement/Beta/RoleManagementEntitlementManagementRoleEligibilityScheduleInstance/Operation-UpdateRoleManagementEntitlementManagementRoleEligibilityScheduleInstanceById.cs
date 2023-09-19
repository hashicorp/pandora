// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.RoleManagement.Beta.RoleManagementEntitlementManagementRoleEligibilityScheduleInstance;

internal class UpdateRoleManagementEntitlementManagementRoleEligibilityScheduleInstanceByIdOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(UnifiedRoleEligibilityScheduleInstanceModel);
    public override ResourceID? ResourceId() => new RoleManagementEntitlementManagementRoleEligibilityScheduleInstanceId();
    public override Type? ResponseObject() => typeof(UnifiedRoleEligibilityScheduleInstanceModel);
    public override string? UriSuffix() => null;
}
