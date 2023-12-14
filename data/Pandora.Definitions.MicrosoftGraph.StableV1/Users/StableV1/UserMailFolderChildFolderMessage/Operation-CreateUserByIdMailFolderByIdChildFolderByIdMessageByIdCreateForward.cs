// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserMailFolderChildFolderMessage;

internal class CreateUserByIdMailFolderByIdChildFolderByIdMessageByIdCreateForwardOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(CreateUserByIdMailFolderByIdChildFolderByIdMessageByIdCreateForwardRequestModel);
    public override ResourceID? ResourceId() => new UserIdMailFolderIdChildFolderIdMessageId();
    public override Type? ResponseObject() => typeof(MessageModel);
    public override string? UriSuffix() => "/createForward";
}
