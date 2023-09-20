// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserJoinedTeamPrimaryChannelMessageReply;

internal class Definition : ResourceDefinition
{
    public string Name => "UserJoinedTeamPrimaryChannelMessageReply";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdJoinedTeamByIdPrimaryChannelMessageByIdReplyByIdSoftDeleteOperation(),
        new CreateUserByIdJoinedTeamByIdPrimaryChannelMessageByIdReplyByIdUndoSoftDeleteOperation(),
        new CreateUserByIdJoinedTeamByIdPrimaryChannelMessageByIdReplyOperation(),
        new DeleteUserByIdJoinedTeamByIdPrimaryChannelMessageByIdReplyByIdOperation(),
        new GetUserByIdJoinedTeamByIdPrimaryChannelMessageByIdReplyByIdOperation(),
        new GetUserByIdJoinedTeamByIdPrimaryChannelMessageByIdReplyCountOperation(),
        new ListUserByIdJoinedTeamByIdPrimaryChannelMessageByIdRepliesOperation(),
        new SetUserByIdJoinedTeamByIdPrimaryChannelMessageByIdReplyByIdReactionOperation(),
        new UnsetUserByIdJoinedTeamByIdPrimaryChannelMessageByIdReplyByIdReactionOperation(),
        new UpdateUserByIdJoinedTeamByIdPrimaryChannelMessageByIdReplyByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(SetUserByIdJoinedTeamByIdPrimaryChannelMessageByIdReplyByIdReactionRequestModel),
        typeof(UnsetUserByIdJoinedTeamByIdPrimaryChannelMessageByIdReplyByIdReactionRequestModel)
    };
}
