// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeJoinedTeamChannelMessage;

internal class Definition : ResourceDefinition
{
    public string Name => "MeJoinedTeamChannelMessage";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeJoinedTeamByIdChannelByIdMessageByIdSoftDeleteOperation(),
        new CreateMeJoinedTeamByIdChannelByIdMessageByIdUndoSoftDeleteOperation(),
        new CreateMeJoinedTeamByIdChannelByIdMessageOperation(),
        new DeleteMeJoinedTeamByIdChannelByIdMessageByIdOperation(),
        new GetMeJoinedTeamByIdChannelByIdMessageByIdOperation(),
        new GetMeJoinedTeamByIdChannelByIdMessageCountOperation(),
        new ListMeJoinedTeamByIdChannelByIdMessagesOperation(),
        new SetMeJoinedTeamByIdChannelByIdMessageByIdReactionOperation(),
        new UnsetMeJoinedTeamByIdChannelByIdMessageByIdReactionOperation(),
        new UpdateMeJoinedTeamByIdChannelByIdMessageByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(SetMeJoinedTeamByIdChannelByIdMessageByIdReactionRequestModel),
        typeof(UnsetMeJoinedTeamByIdChannelByIdMessageByIdReactionRequestModel)
    };
}
