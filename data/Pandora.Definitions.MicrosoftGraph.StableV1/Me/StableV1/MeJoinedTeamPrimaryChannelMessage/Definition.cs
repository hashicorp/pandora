// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeJoinedTeamPrimaryChannelMessage;

internal class Definition : ResourceDefinition
{
    public string Name => "MeJoinedTeamPrimaryChannelMessage";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeJoinedTeamByIdPrimaryChannelMessageByIdSoftDeleteOperation(),
        new CreateMeJoinedTeamByIdPrimaryChannelMessageByIdUndoSoftDeleteOperation(),
        new CreateMeJoinedTeamByIdPrimaryChannelMessageOperation(),
        new DeleteMeJoinedTeamByIdPrimaryChannelMessageByIdOperation(),
        new GetMeJoinedTeamByIdPrimaryChannelMessageByIdOperation(),
        new GetMeJoinedTeamByIdPrimaryChannelMessageCountOperation(),
        new ListMeJoinedTeamByIdPrimaryChannelMessagesOperation(),
        new SetMeJoinedTeamByIdPrimaryChannelMessageByIdReactionOperation(),
        new UnsetMeJoinedTeamByIdPrimaryChannelMessageByIdReactionOperation(),
        new UpdateMeJoinedTeamByIdPrimaryChannelMessageByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(SetMeJoinedTeamByIdPrimaryChannelMessageByIdReactionRequestModel),
        typeof(UnsetMeJoinedTeamByIdPrimaryChannelMessageByIdReactionRequestModel)
    };
}
