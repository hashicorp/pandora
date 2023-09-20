// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserJoinedTeamTagMember;

internal class CreateUserByIdJoinedTeamByIdTagByIdMemberOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(TeamworkTagMemberModel);
    public override ResourceID? ResourceId() => new UserIdJoinedTeamIdTagId();
    public override Type? ResponseObject() => typeof(TeamworkTagMemberModel);
    public override string? UriSuffix() => "/members";
}
