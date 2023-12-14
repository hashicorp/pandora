// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserJoinedTeamChannelMessageHostedContent;

internal class Definition : ResourceDefinition
{
    public string Name => "UserJoinedTeamChannelMessageHostedContent";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUpdateUserByIdJoinedTeamByIdChannelByIdMessageByIdHostedContentByIdValueOperation(),
        new CreateUserByIdJoinedTeamByIdChannelByIdMessageByIdHostedContentOperation(),
        new DeleteUserByIdJoinedTeamByIdChannelByIdMessageByIdHostedContentByIdOperation(),
        new GetUserByIdJoinedTeamByIdChannelByIdMessageByIdHostedContentByIdOperation(),
        new GetUserByIdJoinedTeamByIdChannelByIdMessageByIdHostedContentByIdValueOperation(),
        new GetUserByIdJoinedTeamByIdChannelByIdMessageByIdHostedContentCountOperation(),
        new ListUserByIdJoinedTeamByIdChannelByIdMessageByIdHostedContentsOperation(),
        new UpdateUserByIdJoinedTeamByIdChannelByIdMessageByIdHostedContentByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
