// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.RoleManagement.Beta.RoleManagementCloudPCRoleAssignmentRoleDefinition;

internal class GetRoleManagementCloudPCRoleAssignmentByIdRoleDefinitionOperation : Operations.GetOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override ResourceID? ResourceId() => new RoleManagementCloudPCRoleAssignmentId();
    public override Type? ResponseObject() => typeof(UnifiedRoleDefinitionModel);
    public override string? UriSuffix() => "/roleDefinition";
}
