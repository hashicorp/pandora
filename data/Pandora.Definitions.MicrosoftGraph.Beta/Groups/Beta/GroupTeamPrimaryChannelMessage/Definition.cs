// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupTeamPrimaryChannelMessage;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupTeamPrimaryChannelMessage";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdTeamPrimaryChannelMessageByIdSoftDeleteOperation(),
        new CreateGroupByIdTeamPrimaryChannelMessageByIdUndoSoftDeleteOperation(),
        new CreateGroupByIdTeamPrimaryChannelMessageOperation(),
        new DeleteGroupByIdTeamPrimaryChannelMessageByIdOperation(),
        new GetGroupByIdTeamPrimaryChannelMessageByIdOperation(),
        new GetGroupByIdTeamPrimaryChannelMessageCountOperation(),
        new ListGroupByIdTeamPrimaryChannelMessagesOperation(),
        new SetGroupByIdTeamPrimaryChannelMessageByIdReactionOperation(),
        new UnsetGroupByIdTeamPrimaryChannelMessageByIdReactionOperation(),
        new UpdateGroupByIdTeamPrimaryChannelMessageByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(SetGroupByIdTeamPrimaryChannelMessageByIdReactionRequestModel),
        typeof(UnsetGroupByIdTeamPrimaryChannelMessageByIdReactionRequestModel)
    };
}
