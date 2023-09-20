// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeMailFolderChildFolderMessage;

internal class CreateMeMailFolderByIdChildFolderByIdMessageByIdReplyAllOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.NoContent,
        };
    public override Type? RequestObject() => typeof(CreateMeMailFolderByIdChildFolderByIdMessageByIdReplyAllRequestModel);
    public override ResourceID? ResourceId() => new MeMailFolderIdChildFolderIdMessageId();
    public override Type? ResponseObject() => null;
    public override string? UriSuffix() => "/replyAll";
}
