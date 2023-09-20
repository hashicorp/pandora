// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeMessage;

internal class CreateMeMessageByIdCreateReplyAllOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(CreateMeMessageByIdCreateReplyAllRequestModel);
    public override ResourceID? ResourceId() => new MeMessageId();
    public override Type? ResponseObject() => typeof(MessageModel);
    public override string? UriSuffix() => "/createReplyAll";
}
