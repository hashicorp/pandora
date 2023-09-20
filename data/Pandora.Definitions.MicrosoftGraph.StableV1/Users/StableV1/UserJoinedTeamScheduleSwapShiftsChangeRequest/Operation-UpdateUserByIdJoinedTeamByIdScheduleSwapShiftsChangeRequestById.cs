// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserJoinedTeamScheduleSwapShiftsChangeRequest;

internal class UpdateUserByIdJoinedTeamByIdScheduleSwapShiftsChangeRequestByIdOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(SwapShiftsChangeRequestModel);
    public override ResourceID? ResourceId() => new UserIdJoinedTeamIdScheduleSwapShiftsChangeRequestId();
    public override Type? ResponseObject() => typeof(SwapShiftsChangeRequestModel);
    public override string? UriSuffix() => null;
}
