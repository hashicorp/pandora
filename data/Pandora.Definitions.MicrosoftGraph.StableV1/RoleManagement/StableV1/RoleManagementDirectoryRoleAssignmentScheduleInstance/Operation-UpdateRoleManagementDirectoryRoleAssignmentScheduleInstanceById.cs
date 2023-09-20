// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.RoleManagement.StableV1.RoleManagementDirectoryRoleAssignmentScheduleInstance;

internal class UpdateRoleManagementDirectoryRoleAssignmentScheduleInstanceByIdOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(UnifiedRoleAssignmentScheduleInstanceModel);
    public override ResourceID? ResourceId() => new RoleManagementDirectoryRoleAssignmentScheduleInstanceId();
    public override Type? ResponseObject() => typeof(UnifiedRoleAssignmentScheduleInstanceModel);
    public override string? UriSuffix() => null;
}
