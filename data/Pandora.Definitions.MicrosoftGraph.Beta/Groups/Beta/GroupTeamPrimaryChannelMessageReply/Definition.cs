// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupTeamPrimaryChannelMessageReply;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupTeamPrimaryChannelMessageReply";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdTeamPrimaryChannelMessageByIdReplyByIdSoftDeleteOperation(),
        new CreateGroupByIdTeamPrimaryChannelMessageByIdReplyByIdUndoSoftDeleteOperation(),
        new CreateGroupByIdTeamPrimaryChannelMessageByIdReplyOperation(),
        new DeleteGroupByIdTeamPrimaryChannelMessageByIdReplyByIdOperation(),
        new GetGroupByIdTeamPrimaryChannelMessageByIdReplyByIdOperation(),
        new GetGroupByIdTeamPrimaryChannelMessageByIdReplyCountOperation(),
        new ListGroupByIdTeamPrimaryChannelMessageByIdRepliesOperation(),
        new SetGroupByIdTeamPrimaryChannelMessageByIdReplyByIdReactionOperation(),
        new UnsetGroupByIdTeamPrimaryChannelMessageByIdReplyByIdReactionOperation(),
        new UpdateGroupByIdTeamPrimaryChannelMessageByIdReplyByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(SetGroupByIdTeamPrimaryChannelMessageByIdReplyByIdReactionRequestModel),
        typeof(UnsetGroupByIdTeamPrimaryChannelMessageByIdReplyByIdReactionRequestModel)
    };
}
