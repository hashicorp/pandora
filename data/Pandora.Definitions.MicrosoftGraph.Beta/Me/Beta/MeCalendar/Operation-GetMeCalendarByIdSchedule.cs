// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeCalendar;

internal class GetMeCalendarByIdScheduleOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(GetMeCalendarByIdScheduleRequestModel);
    public override ResourceID? ResourceId() => new MeCalendarId();
    public override Type? ResponseObject() => typeof(BaseCollectionPaginationCountResponseModel);
    public override string? UriSuffix() => "/getSchedule";
}
