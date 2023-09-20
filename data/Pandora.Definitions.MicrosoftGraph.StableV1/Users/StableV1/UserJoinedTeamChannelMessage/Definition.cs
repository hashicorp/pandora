// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserJoinedTeamChannelMessage;

internal class Definition : ResourceDefinition
{
    public string Name => "UserJoinedTeamChannelMessage";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdJoinedTeamByIdChannelByIdMessageByIdSoftDeleteOperation(),
        new CreateUserByIdJoinedTeamByIdChannelByIdMessageByIdUndoSoftDeleteOperation(),
        new CreateUserByIdJoinedTeamByIdChannelByIdMessageOperation(),
        new DeleteUserByIdJoinedTeamByIdChannelByIdMessageByIdOperation(),
        new GetUserByIdJoinedTeamByIdChannelByIdMessageByIdOperation(),
        new GetUserByIdJoinedTeamByIdChannelByIdMessageCountOperation(),
        new ListUserByIdJoinedTeamByIdChannelByIdMessagesOperation(),
        new SetUserByIdJoinedTeamByIdChannelByIdMessageByIdReactionOperation(),
        new UnsetUserByIdJoinedTeamByIdChannelByIdMessageByIdReactionOperation(),
        new UpdateUserByIdJoinedTeamByIdChannelByIdMessageByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(SetUserByIdJoinedTeamByIdChannelByIdMessageByIdReactionRequestModel),
        typeof(UnsetUserByIdJoinedTeamByIdChannelByIdMessageByIdReactionRequestModel)
    };
}
