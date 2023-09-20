// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserJoinedTeamPermissionGrant;

internal class Definition : ResourceDefinition
{
    public string Name => "UserJoinedTeamPermissionGrant";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckUserByIdJoinedTeamByIdPermissionGrantByIdMemberGroupOperation(),
        new CheckUserByIdJoinedTeamByIdPermissionGrantByIdMemberObjectOperation(),
        new CreateUserByIdJoinedTeamByIdPermissionGrantOperation(),
        new DeleteUserByIdJoinedTeamByIdPermissionGrantByIdOperation(),
        new GetUserByIdJoinedTeamByIdPermissionGrantByIdMemberGroupOperation(),
        new GetUserByIdJoinedTeamByIdPermissionGrantByIdMemberObjectOperation(),
        new GetUserByIdJoinedTeamByIdPermissionGrantByIdOperation(),
        new GetUserByIdJoinedTeamByIdPermissionGrantCountOperation(),
        new GetUserByIdJoinedTeamByIdPermissionGrantsAvailableExtensionPropertiesOperation(),
        new GetUserByIdJoinedTeamByIdPermissionGrantsByIdsOperation(),
        new ListUserByIdJoinedTeamByIdPermissionGrantsOperation(),
        new RestoreUserByIdJoinedTeamByIdPermissionGrantByIdOperation(),
        new UpdateUserByIdJoinedTeamByIdPermissionGrantByIdOperation(),
        new ValidateUserByIdJoinedTeamByIdPermissionGrantsPropertyOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CheckUserByIdJoinedTeamByIdPermissionGrantByIdMemberGroupRequestModel),
        typeof(CheckUserByIdJoinedTeamByIdPermissionGrantByIdMemberObjectRequestModel),
        typeof(GetUserByIdJoinedTeamByIdPermissionGrantByIdMemberGroupRequestModel),
        typeof(GetUserByIdJoinedTeamByIdPermissionGrantByIdMemberObjectRequestModel),
        typeof(GetUserByIdJoinedTeamByIdPermissionGrantsAvailableExtensionPropertiesRequestModel),
        typeof(GetUserByIdJoinedTeamByIdPermissionGrantsByIdsRequestModel),
        typeof(ValidateUserByIdJoinedTeamByIdPermissionGrantsPropertyRequestModel)
    };
}
