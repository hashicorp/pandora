// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeJoinedTeamChannelMessageHostedContent;

internal class Definition : ResourceDefinition
{
    public string Name => "MeJoinedTeamChannelMessageHostedContent";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeJoinedTeamByIdChannelByIdMessageByIdHostedContentOperation(),
        new CreateUpdateMeJoinedTeamByIdChannelByIdMessageByIdHostedContentByIdValueOperation(),
        new DeleteMeJoinedTeamByIdChannelByIdMessageByIdHostedContentByIdOperation(),
        new GetMeJoinedTeamByIdChannelByIdMessageByIdHostedContentByIdOperation(),
        new GetMeJoinedTeamByIdChannelByIdMessageByIdHostedContentByIdValueOperation(),
        new GetMeJoinedTeamByIdChannelByIdMessageByIdHostedContentCountOperation(),
        new ListMeJoinedTeamByIdChannelByIdMessageByIdHostedContentsOperation(),
        new UpdateMeJoinedTeamByIdChannelByIdMessageByIdHostedContentByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
