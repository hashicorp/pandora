// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserJoinedTeamPrimaryChannelMessageReplyHostedContent;

internal class Definition : ResourceDefinition
{
    public string Name => "UserJoinedTeamPrimaryChannelMessageReplyHostedContent";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUpdateUserByIdJoinedTeamByIdPrimaryChannelMessageByIdReplyByIdHostedContentByIdValueOperation(),
        new CreateUserByIdJoinedTeamByIdPrimaryChannelMessageByIdReplyByIdHostedContentOperation(),
        new DeleteUserByIdJoinedTeamByIdPrimaryChannelMessageByIdReplyByIdHostedContentByIdOperation(),
        new GetUserByIdJoinedTeamByIdPrimaryChannelMessageByIdReplyByIdHostedContentByIdOperation(),
        new GetUserByIdJoinedTeamByIdPrimaryChannelMessageByIdReplyByIdHostedContentByIdValueOperation(),
        new GetUserByIdJoinedTeamByIdPrimaryChannelMessageByIdReplyByIdHostedContentCountOperation(),
        new ListUserByIdJoinedTeamByIdPrimaryChannelMessageByIdReplyByIdHostedContentsOperation(),
        new UpdateUserByIdJoinedTeamByIdPrimaryChannelMessageByIdReplyByIdHostedContentByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
