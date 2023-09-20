// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.RoleManagement.StableV1.RoleManagementDirectoryRoleAssignmentScheduleRequest;

internal class CreateRoleManagementDirectoryRoleAssignmentScheduleRequestOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(UnifiedRoleAssignmentScheduleRequestModel);
    public override ResourceID? ResourceId() => null;
    public override Type? ResponseObject() => typeof(UnifiedRoleAssignmentScheduleRequestModel);
    public override string? UriSuffix() => "/roleManagement/directory/roleAssignmentScheduleRequests";
}
