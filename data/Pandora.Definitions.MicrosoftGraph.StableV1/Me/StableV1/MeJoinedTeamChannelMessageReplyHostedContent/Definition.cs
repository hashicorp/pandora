// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeJoinedTeamChannelMessageReplyHostedContent;

internal class Definition : ResourceDefinition
{
    public string Name => "MeJoinedTeamChannelMessageReplyHostedContent";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeJoinedTeamByIdChannelByIdMessageByIdReplyByIdHostedContentOperation(),
        new CreateUpdateMeJoinedTeamByIdChannelByIdMessageByIdReplyByIdHostedContentByIdValueOperation(),
        new DeleteMeJoinedTeamByIdChannelByIdMessageByIdReplyByIdHostedContentByIdOperation(),
        new GetMeJoinedTeamByIdChannelByIdMessageByIdReplyByIdHostedContentByIdOperation(),
        new GetMeJoinedTeamByIdChannelByIdMessageByIdReplyByIdHostedContentByIdValueOperation(),
        new GetMeJoinedTeamByIdChannelByIdMessageByIdReplyByIdHostedContentCountOperation(),
        new ListMeJoinedTeamByIdChannelByIdMessageByIdReplyByIdHostedContentsOperation(),
        new UpdateMeJoinedTeamByIdChannelByIdMessageByIdReplyByIdHostedContentByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
