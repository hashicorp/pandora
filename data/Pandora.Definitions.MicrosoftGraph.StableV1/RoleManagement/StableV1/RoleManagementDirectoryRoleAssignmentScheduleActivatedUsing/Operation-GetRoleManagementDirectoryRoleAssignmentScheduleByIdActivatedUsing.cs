// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.RoleManagement.StableV1.RoleManagementDirectoryRoleAssignmentScheduleActivatedUsing;

internal class GetRoleManagementDirectoryRoleAssignmentScheduleByIdActivatedUsingOperation : Operations.GetOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override ResourceID? ResourceId() => new RoleManagementDirectoryRoleAssignmentScheduleId();
    public override Type? ResponseObject() => typeof(UnifiedRoleEligibilityScheduleModel);
    public override string? UriSuffix() => "/activatedUsing";
}
