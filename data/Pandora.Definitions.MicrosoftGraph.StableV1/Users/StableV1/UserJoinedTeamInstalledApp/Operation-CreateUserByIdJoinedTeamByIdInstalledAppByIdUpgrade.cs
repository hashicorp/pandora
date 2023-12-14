// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserJoinedTeamInstalledApp;

internal class CreateUserByIdJoinedTeamByIdInstalledAppByIdUpgradeOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.NoContent,
        };
    public override Type? RequestObject() => typeof(CreateUserByIdJoinedTeamByIdInstalledAppByIdUpgradeRequestModel);
    public override ResourceID? ResourceId() => new UserIdJoinedTeamIdInstalledAppId();
    public override Type? ResponseObject() => null;
    public override string? UriSuffix() => "/upgrade";
}
