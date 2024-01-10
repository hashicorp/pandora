// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupTeamPrimaryChannelMessage;

internal class SetGroupByIdTeamPrimaryChannelMessageByIdReactionOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.NoContent,
        };
    public override Type? RequestObject() => typeof(SetGroupByIdTeamPrimaryChannelMessageByIdReactionRequestModel);
    public override ResourceID? ResourceId() => new GroupIdTeamPrimaryChannelMessageId();
    public override Type? ResponseObject() => null;
    public override string? UriSuffix() => "/setReaction";
}
