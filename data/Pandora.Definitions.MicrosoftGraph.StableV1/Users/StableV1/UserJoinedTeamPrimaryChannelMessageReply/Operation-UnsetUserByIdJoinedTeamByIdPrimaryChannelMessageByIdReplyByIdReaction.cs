// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserJoinedTeamPrimaryChannelMessageReply;

internal class UnsetUserByIdJoinedTeamByIdPrimaryChannelMessageByIdReplyByIdReactionOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.NoContent,
        };
    public override Type? RequestObject() => typeof(UnsetUserByIdJoinedTeamByIdPrimaryChannelMessageByIdReplyByIdReactionRequestModel);
    public override ResourceID? ResourceId() => new UserIdJoinedTeamIdPrimaryChannelMessageIdReplyId();
    public override Type? ResponseObject() => null;
    public override string? UriSuffix() => "/unsetReaction";
}
