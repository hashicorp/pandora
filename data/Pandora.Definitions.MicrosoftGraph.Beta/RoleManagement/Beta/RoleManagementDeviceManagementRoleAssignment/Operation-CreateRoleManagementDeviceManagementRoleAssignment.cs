// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.RoleManagement.Beta.RoleManagementDeviceManagementRoleAssignment;

internal class CreateRoleManagementDeviceManagementRoleAssignmentOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(UnifiedRoleAssignmentMultipleModel);
    public override ResourceID? ResourceId() => null;
    public override Type? ResponseObject() => typeof(UnifiedRoleAssignmentMultipleModel);
    public override string? UriSuffix() => "/roleManagement/deviceManagement/roleAssignments";
}
