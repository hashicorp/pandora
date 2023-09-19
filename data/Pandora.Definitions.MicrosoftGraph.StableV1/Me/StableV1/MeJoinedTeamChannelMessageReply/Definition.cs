// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeJoinedTeamChannelMessageReply;

internal class Definition : ResourceDefinition
{
    public string Name => "MeJoinedTeamChannelMessageReply";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeJoinedTeamByIdChannelByIdMessageByIdReplyByIdSoftDeleteOperation(),
        new CreateMeJoinedTeamByIdChannelByIdMessageByIdReplyByIdUndoSoftDeleteOperation(),
        new CreateMeJoinedTeamByIdChannelByIdMessageByIdReplyOperation(),
        new DeleteMeJoinedTeamByIdChannelByIdMessageByIdReplyByIdOperation(),
        new GetMeJoinedTeamByIdChannelByIdMessageByIdReplyByIdOperation(),
        new GetMeJoinedTeamByIdChannelByIdMessageByIdReplyCountOperation(),
        new ListMeJoinedTeamByIdChannelByIdMessageByIdRepliesOperation(),
        new SetMeJoinedTeamByIdChannelByIdMessageByIdReplyByIdReactionOperation(),
        new UnsetMeJoinedTeamByIdChannelByIdMessageByIdReplyByIdReactionOperation(),
        new UpdateMeJoinedTeamByIdChannelByIdMessageByIdReplyByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(SetMeJoinedTeamByIdChannelByIdMessageByIdReplyByIdReactionRequestModel),
        typeof(UnsetMeJoinedTeamByIdChannelByIdMessageByIdReplyByIdReactionRequestModel)
    };
}
