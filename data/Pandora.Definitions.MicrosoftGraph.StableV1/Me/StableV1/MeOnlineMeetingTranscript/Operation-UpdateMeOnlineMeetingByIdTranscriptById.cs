// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeOnlineMeetingTranscript;

internal class UpdateMeOnlineMeetingByIdTranscriptByIdOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(CallTranscriptModel);
    public override ResourceID? ResourceId() => new MeOnlineMeetingIdTranscriptId();
    public override Type? ResponseObject() => typeof(CallTranscriptModel);
    public override string? UriSuffix() => null;
}
