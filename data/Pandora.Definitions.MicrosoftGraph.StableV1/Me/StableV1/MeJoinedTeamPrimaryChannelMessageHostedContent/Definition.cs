// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeJoinedTeamPrimaryChannelMessageHostedContent;

internal class Definition : ResourceDefinition
{
    public string Name => "MeJoinedTeamPrimaryChannelMessageHostedContent";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeJoinedTeamByIdPrimaryChannelMessageByIdHostedContentOperation(),
        new CreateUpdateMeJoinedTeamByIdPrimaryChannelMessageByIdHostedContentByIdValueOperation(),
        new DeleteMeJoinedTeamByIdPrimaryChannelMessageByIdHostedContentByIdOperation(),
        new GetMeJoinedTeamByIdPrimaryChannelMessageByIdHostedContentByIdOperation(),
        new GetMeJoinedTeamByIdPrimaryChannelMessageByIdHostedContentByIdValueOperation(),
        new GetMeJoinedTeamByIdPrimaryChannelMessageByIdHostedContentCountOperation(),
        new ListMeJoinedTeamByIdPrimaryChannelMessageByIdHostedContentsOperation(),
        new UpdateMeJoinedTeamByIdPrimaryChannelMessageByIdHostedContentByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
