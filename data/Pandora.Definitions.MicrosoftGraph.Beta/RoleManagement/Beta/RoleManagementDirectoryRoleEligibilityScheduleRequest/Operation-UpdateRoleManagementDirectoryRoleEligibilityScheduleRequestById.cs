// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.RoleManagement.Beta.RoleManagementDirectoryRoleEligibilityScheduleRequest;

internal class UpdateRoleManagementDirectoryRoleEligibilityScheduleRequestByIdOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(UnifiedRoleEligibilityScheduleRequestModel);
    public override ResourceID? ResourceId() => new RoleManagementDirectoryRoleEligibilityScheduleRequestId();
    public override Type? ResponseObject() => typeof(UnifiedRoleEligibilityScheduleRequestModel);
    public override string? UriSuffix() => null;
}
