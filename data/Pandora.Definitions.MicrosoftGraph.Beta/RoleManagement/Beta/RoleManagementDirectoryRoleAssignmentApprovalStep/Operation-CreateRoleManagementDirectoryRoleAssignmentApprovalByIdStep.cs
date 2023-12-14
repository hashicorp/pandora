// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.RoleManagement.Beta.RoleManagementDirectoryRoleAssignmentApprovalStep;

internal class CreateRoleManagementDirectoryRoleAssignmentApprovalByIdStepOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(ApprovalStepModel);
    public override ResourceID? ResourceId() => new RoleManagementDirectoryRoleAssignmentApprovalId();
    public override Type? ResponseObject() => typeof(ApprovalStepModel);
    public override string? UriSuffix() => "/steps";
}
