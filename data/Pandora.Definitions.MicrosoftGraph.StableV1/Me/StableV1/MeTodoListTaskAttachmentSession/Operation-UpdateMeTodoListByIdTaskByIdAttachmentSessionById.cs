// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeTodoListTaskAttachmentSession;

internal class UpdateMeTodoListByIdTaskByIdAttachmentSessionByIdOperation : Operations.PatchOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(AttachmentSessionModel);
    public override ResourceID? ResourceId() => new MeTodoListIdTaskIdAttachmentSessionId();
    public override Type? ResponseObject() => typeof(AttachmentSessionModel);
    public override string? UriSuffix() => null;
}
