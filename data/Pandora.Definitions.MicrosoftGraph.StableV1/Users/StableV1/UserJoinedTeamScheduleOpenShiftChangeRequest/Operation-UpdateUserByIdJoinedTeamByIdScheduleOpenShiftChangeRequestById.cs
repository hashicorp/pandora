// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserJoinedTeamScheduleOpenShiftChangeRequest;

internal class UpdateUserByIdJoinedTeamByIdScheduleOpenShiftChangeRequestByIdOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(OpenShiftChangeRequestModel);
    public override ResourceID? ResourceId() => new UserIdJoinedTeamIdScheduleOpenShiftChangeRequestId();
    public override Type? ResponseObject() => typeof(OpenShiftChangeRequestModel);
    public override string? UriSuffix() => null;
}
