// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserJoinedTeamPrimaryChannelMessage;

internal class Definition : ResourceDefinition
{
    public string Name => "UserJoinedTeamPrimaryChannelMessage";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdJoinedTeamByIdPrimaryChannelMessageByIdSoftDeleteOperation(),
        new CreateUserByIdJoinedTeamByIdPrimaryChannelMessageByIdUndoSoftDeleteOperation(),
        new CreateUserByIdJoinedTeamByIdPrimaryChannelMessageOperation(),
        new DeleteUserByIdJoinedTeamByIdPrimaryChannelMessageByIdOperation(),
        new GetUserByIdJoinedTeamByIdPrimaryChannelMessageByIdOperation(),
        new GetUserByIdJoinedTeamByIdPrimaryChannelMessageCountOperation(),
        new ListUserByIdJoinedTeamByIdPrimaryChannelMessagesOperation(),
        new SetUserByIdJoinedTeamByIdPrimaryChannelMessageByIdReactionOperation(),
        new UnsetUserByIdJoinedTeamByIdPrimaryChannelMessageByIdReactionOperation(),
        new UpdateUserByIdJoinedTeamByIdPrimaryChannelMessageByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(SetUserByIdJoinedTeamByIdPrimaryChannelMessageByIdReactionRequestModel),
        typeof(UnsetUserByIdJoinedTeamByIdPrimaryChannelMessageByIdReactionRequestModel)
    };
}
