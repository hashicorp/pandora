// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeCalendarCalendarViewInstance;

internal class CreateMeCalendarCalendarViewByIdInstanceByIdTentativelyAcceptOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.NoContent,
        };
    public override Type? RequestObject() => typeof(CreateMeCalendarCalendarViewByIdInstanceByIdTentativelyAcceptRequestModel);
    public override ResourceID? ResourceId() => new MeCalendarCalendarViewIdInstanceId();
    public override Type? ResponseObject() => null;
    public override string? UriSuffix() => "/tentativelyAccept";
}
