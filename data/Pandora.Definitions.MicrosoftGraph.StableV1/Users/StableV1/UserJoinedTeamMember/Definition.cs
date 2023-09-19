// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserJoinedTeamMember;

internal class Definition : ResourceDefinition
{
    public string Name => "UserJoinedTeamMember";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AddUserByIdJoinedTeamByIdMemberOperation(),
        new CreateUserByIdJoinedTeamByIdMemberOperation(),
        new DeleteUserByIdJoinedTeamByIdMemberByIdOperation(),
        new GetUserByIdJoinedTeamByIdMemberByIdOperation(),
        new GetUserByIdJoinedTeamByIdMemberCountOperation(),
        new ListUserByIdJoinedTeamByIdMembersOperation(),
        new UpdateUserByIdJoinedTeamByIdMemberByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AddUserByIdJoinedTeamByIdMemberRequestModel)
    };
}
