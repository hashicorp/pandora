// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupTeamChannelMessage;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupTeamChannelMessage";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdTeamChannelByIdMessageByIdSoftDeleteOperation(),
        new CreateGroupByIdTeamChannelByIdMessageByIdUndoSoftDeleteOperation(),
        new CreateGroupByIdTeamChannelByIdMessageOperation(),
        new DeleteGroupByIdTeamChannelByIdMessageByIdOperation(),
        new GetGroupByIdTeamChannelByIdMessageByIdOperation(),
        new GetGroupByIdTeamChannelByIdMessageCountOperation(),
        new ListGroupByIdTeamChannelByIdMessagesOperation(),
        new SetGroupByIdTeamChannelByIdMessageByIdReactionOperation(),
        new UnsetGroupByIdTeamChannelByIdMessageByIdReactionOperation(),
        new UpdateGroupByIdTeamChannelByIdMessageByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(SetGroupByIdTeamChannelByIdMessageByIdReactionRequestModel),
        typeof(UnsetGroupByIdTeamChannelByIdMessageByIdReactionRequestModel)
    };
}
