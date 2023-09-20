// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserJoinedTeamInstalledAppTeamsAppDefinition;

internal class GetUserByIdJoinedTeamByIdInstalledAppByIdTeamsAppDefinitionOperation : Operations.GetOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override ResourceID? ResourceId() => new UserIdJoinedTeamIdInstalledAppId();
    public override Type? ResponseObject() => typeof(TeamsAppDefinitionModel);
    public override string? UriSuffix() => "/teamsAppDefinition";
}
