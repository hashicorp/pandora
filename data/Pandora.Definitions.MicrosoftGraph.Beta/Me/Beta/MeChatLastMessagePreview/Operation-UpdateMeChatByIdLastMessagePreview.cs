// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeChatLastMessagePreview;

internal class UpdateMeChatByIdLastMessagePreviewOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(ChatMessageInfoModel);
    public override ResourceID? ResourceId() => new MeChatId();
    public override Type? ResponseObject() => typeof(ChatMessageInfoModel);
    public override string? UriSuffix() => "/lastMessagePreview";
}
