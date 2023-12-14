// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeJoinedTeamScheduleOfferShiftRequest;

internal class UpdateMeJoinedTeamByIdScheduleOfferShiftRequestByIdOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(OfferShiftRequestModel);
    public override ResourceID? ResourceId() => new MeJoinedTeamIdScheduleOfferShiftRequestId();
    public override Type? ResponseObject() => typeof(OfferShiftRequestModel);
    public override string? UriSuffix() => null;
}
