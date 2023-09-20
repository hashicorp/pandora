// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserTodoListTaskAttachment;

internal class CreateUserByIdTodoListByIdTaskByIdAttachmentOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(AttachmentBaseModel);
    public override ResourceID? ResourceId() => new UserIdTodoListIdTaskId();
    public override Type? ResponseObject() => typeof(AttachmentBaseModel);
    public override string? UriSuffix() => "/attachments";
}
