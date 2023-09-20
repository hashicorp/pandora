// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeMailFolderChildFolderMessageRule;

internal class CreateMeMailFolderByIdChildFolderByIdMessageRuleOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(MessageRuleModel);
    public override ResourceID? ResourceId() => new MeMailFolderIdChildFolderId();
    public override Type? ResponseObject() => typeof(MessageRuleModel);
    public override string? UriSuffix() => "/messageRules";
}
