// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeJoinedTeam;

internal class Definition : ResourceDefinition
{
    public string Name => "MeJoinedTeam";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeJoinedTeamByIdArchiveOperation(),
        new CreateMeJoinedTeamByIdCloneOperation(),
        new CreateMeJoinedTeamByIdCompleteMigrationOperation(),
        new CreateMeJoinedTeamByIdSendActivityNotificationOperation(),
        new CreateMeJoinedTeamByIdUnarchiveOperation(),
        new CreateMeJoinedTeamOperation(),
        new DeleteMeJoinedTeamByIdOperation(),
        new GetMeJoinedTeamByIdOperation(),
        new GetMeJoinedTeamCountOperation(),
        new ListMeJoinedTeamsOperation(),
        new UpdateMeJoinedTeamByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CreateMeJoinedTeamByIdCloneRequestPartsToCloneConstant),
        typeof(CreateMeJoinedTeamByIdCloneRequestVisibilityConstant)
    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeJoinedTeamByIdArchiveRequestModel),
        typeof(CreateMeJoinedTeamByIdCloneRequestModel),
        typeof(CreateMeJoinedTeamByIdSendActivityNotificationRequestModel)
    };
}
