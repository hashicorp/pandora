// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeJoinedTeamChannel;

internal class Definition : ResourceDefinition
{
    public string Name => "MeJoinedTeamChannel";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeJoinedTeamByIdChannelByIdCompleteMigrationOperation(),
        new CreateMeJoinedTeamByIdChannelOperation(),
        new DeleteMeJoinedTeamByIdChannelByIdOperation(),
        new GetMeJoinedTeamByIdChannelByIdOperation(),
        new GetMeJoinedTeamByIdChannelCountOperation(),
        new ListMeJoinedTeamByIdChannelsOperation(),
        new ProvisionMeJoinedTeamByIdChannelByIdEmailOperation(),
        new RemoveMeJoinedTeamByIdChannelByIdEmailOperation(),
        new UpdateMeJoinedTeamByIdChannelByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
