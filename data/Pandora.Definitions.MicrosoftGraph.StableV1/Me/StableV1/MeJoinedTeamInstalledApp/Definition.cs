// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeJoinedTeamInstalledApp;

internal class Definition : ResourceDefinition
{
    public string Name => "MeJoinedTeamInstalledApp";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeJoinedTeamByIdInstalledAppByIdUpgradeOperation(),
        new CreateMeJoinedTeamByIdInstalledAppOperation(),
        new DeleteMeJoinedTeamByIdInstalledAppByIdOperation(),
        new GetMeJoinedTeamByIdInstalledAppByIdOperation(),
        new GetMeJoinedTeamByIdInstalledAppCountOperation(),
        new ListMeJoinedTeamByIdInstalledAppsOperation(),
        new UpdateMeJoinedTeamByIdInstalledAppByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeJoinedTeamByIdInstalledAppByIdUpgradeRequestModel)
    };
}
