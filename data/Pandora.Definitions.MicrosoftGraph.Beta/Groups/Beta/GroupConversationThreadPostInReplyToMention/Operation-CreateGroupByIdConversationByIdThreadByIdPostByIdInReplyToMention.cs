// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupConversationThreadPostInReplyToMention;

internal class CreateGroupByIdConversationByIdThreadByIdPostByIdInReplyToMentionOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(MentionModel);
    public override ResourceID? ResourceId() => new GroupIdConversationIdThreadIdPostId();
    public override Type? ResponseObject() => typeof(MentionModel);
    public override string? UriSuffix() => "/inReplyTo/mentions";
}
