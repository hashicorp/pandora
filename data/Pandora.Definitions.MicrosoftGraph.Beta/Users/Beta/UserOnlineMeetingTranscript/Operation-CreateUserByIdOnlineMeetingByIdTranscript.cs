// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserOnlineMeetingTranscript;

internal class CreateUserByIdOnlineMeetingByIdTranscriptOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(CallTranscriptModel);
    public override ResourceID? ResourceId() => new UserIdOnlineMeetingId();
    public override Type? ResponseObject() => typeof(CallTranscriptModel);
    public override string? UriSuffix() => "/transcripts";
}
