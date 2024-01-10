// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupTeamScheduleTimeCard;

internal class CreateGroupByIdTeamScheduleTimeCardByIdClockOutOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(CreateGroupByIdTeamScheduleTimeCardByIdClockOutRequestModel);
    public override ResourceID? ResourceId() => new GroupIdTeamScheduleTimeCardId();
    public override Type? ResponseObject() => typeof(TimeCardModel);
    public override string? UriSuffix() => "/clockOut";
}
