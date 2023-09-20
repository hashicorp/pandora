// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserJoinedTeamPrimaryChannelMember;

internal class Definition : ResourceDefinition
{
    public string Name => "UserJoinedTeamPrimaryChannelMember";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AddUserByIdJoinedTeamByIdPrimaryChannelMemberOperation(),
        new CreateUserByIdJoinedTeamByIdPrimaryChannelMemberOperation(),
        new DeleteUserByIdJoinedTeamByIdPrimaryChannelMemberByIdOperation(),
        new GetUserByIdJoinedTeamByIdPrimaryChannelMemberByIdOperation(),
        new GetUserByIdJoinedTeamByIdPrimaryChannelMemberCountOperation(),
        new ListUserByIdJoinedTeamByIdPrimaryChannelMembersOperation(),
        new UpdateUserByIdJoinedTeamByIdPrimaryChannelMemberByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AddUserByIdJoinedTeamByIdPrimaryChannelMemberRequestModel)
    };
}
