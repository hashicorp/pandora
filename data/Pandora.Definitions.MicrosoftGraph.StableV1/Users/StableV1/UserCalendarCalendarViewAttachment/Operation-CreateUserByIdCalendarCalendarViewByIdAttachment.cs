// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserCalendarCalendarViewAttachment;

internal class CreateUserByIdCalendarCalendarViewByIdAttachmentOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(AttachmentModel);
    public override ResourceID? ResourceId() => new UserIdCalendarCalendarViewId();
    public override Type? ResponseObject() => typeof(AttachmentModel);
    public override string? UriSuffix() => "/attachments";
}
