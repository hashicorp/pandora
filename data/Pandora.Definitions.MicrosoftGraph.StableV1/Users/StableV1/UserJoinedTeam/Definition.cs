// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserJoinedTeam;

internal class Definition : ResourceDefinition
{
    public string Name => "UserJoinedTeam";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdJoinedTeamByIdArchiveOperation(),
        new CreateUserByIdJoinedTeamByIdCloneOperation(),
        new CreateUserByIdJoinedTeamByIdCompleteMigrationOperation(),
        new CreateUserByIdJoinedTeamByIdSendActivityNotificationOperation(),
        new CreateUserByIdJoinedTeamByIdUnarchiveOperation(),
        new CreateUserByIdJoinedTeamOperation(),
        new DeleteUserByIdJoinedTeamByIdOperation(),
        new GetUserByIdJoinedTeamByIdOperation(),
        new GetUserByIdJoinedTeamCountOperation(),
        new ListUserByIdJoinedTeamsOperation(),
        new UpdateUserByIdJoinedTeamByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CreateUserByIdJoinedTeamByIdCloneRequestPartsToCloneConstant),
        typeof(CreateUserByIdJoinedTeamByIdCloneRequestVisibilityConstant)
    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdJoinedTeamByIdArchiveRequestModel),
        typeof(CreateUserByIdJoinedTeamByIdCloneRequestModel),
        typeof(CreateUserByIdJoinedTeamByIdSendActivityNotificationRequestModel)
    };
}
