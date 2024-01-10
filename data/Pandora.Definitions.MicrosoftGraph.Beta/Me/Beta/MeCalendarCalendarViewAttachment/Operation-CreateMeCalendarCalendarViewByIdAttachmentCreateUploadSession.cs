// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeCalendarCalendarViewAttachment;

internal class CreateMeCalendarCalendarViewByIdAttachmentCreateUploadSessionOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(CreateMeCalendarCalendarViewByIdAttachmentCreateUploadSessionRequestModel);
    public override ResourceID? ResourceId() => new MeCalendarCalendarViewId();
    public override Type? ResponseObject() => typeof(UploadSessionModel);
    public override string? UriSuffix() => "/attachments/createUploadSession";
}
