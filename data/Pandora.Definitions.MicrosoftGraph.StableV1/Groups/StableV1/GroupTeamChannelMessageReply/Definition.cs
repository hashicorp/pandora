// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupTeamChannelMessageReply;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupTeamChannelMessageReply";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdTeamChannelByIdMessageByIdReplyByIdSoftDeleteOperation(),
        new CreateGroupByIdTeamChannelByIdMessageByIdReplyByIdUndoSoftDeleteOperation(),
        new CreateGroupByIdTeamChannelByIdMessageByIdReplyOperation(),
        new DeleteGroupByIdTeamChannelByIdMessageByIdReplyByIdOperation(),
        new GetGroupByIdTeamChannelByIdMessageByIdReplyByIdOperation(),
        new GetGroupByIdTeamChannelByIdMessageByIdReplyCountOperation(),
        new ListGroupByIdTeamChannelByIdMessageByIdRepliesOperation(),
        new SetGroupByIdTeamChannelByIdMessageByIdReplyByIdReactionOperation(),
        new UnsetGroupByIdTeamChannelByIdMessageByIdReplyByIdReactionOperation(),
        new UpdateGroupByIdTeamChannelByIdMessageByIdReplyByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(SetGroupByIdTeamChannelByIdMessageByIdReplyByIdReactionRequestModel),
        typeof(UnsetGroupByIdTeamChannelByIdMessageByIdReplyByIdReactionRequestModel)
    };
}
