// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserMailFolderChildFolderMessageRule;

internal class CreateUserByIdMailFolderByIdChildFolderByIdMessageRuleOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(MessageRuleModel);
    public override ResourceID? ResourceId() => new UserIdMailFolderIdChildFolderId();
    public override Type? ResponseObject() => typeof(MessageRuleModel);
    public override string? UriSuffix() => "/messageRules";
}
