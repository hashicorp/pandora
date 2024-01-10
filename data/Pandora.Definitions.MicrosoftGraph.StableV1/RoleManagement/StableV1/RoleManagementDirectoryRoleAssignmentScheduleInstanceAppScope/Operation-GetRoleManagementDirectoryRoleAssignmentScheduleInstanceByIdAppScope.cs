// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.RoleManagement.StableV1.RoleManagementDirectoryRoleAssignmentScheduleInstanceAppScope;

internal class GetRoleManagementDirectoryRoleAssignmentScheduleInstanceByIdAppScopeOperation : Operations.GetOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override ResourceID? ResourceId() => new RoleManagementDirectoryRoleAssignmentScheduleInstanceId();
    public override Type? ResponseObject() => typeof(AppScopeModel);
    public override string? UriSuffix() => "/appScope";
}
