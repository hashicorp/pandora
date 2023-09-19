// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserPermissionGrant;

internal class Definition : ResourceDefinition
{
    public string Name => "UserPermissionGrant";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckUserByIdPermissionGrantByIdMemberGroupOperation(),
        new CheckUserByIdPermissionGrantByIdMemberObjectOperation(),
        new CreateUserByIdPermissionGrantOperation(),
        new DeleteUserByIdPermissionGrantByIdOperation(),
        new GetUserByIdPermissionGrantByIdMemberGroupOperation(),
        new GetUserByIdPermissionGrantByIdMemberObjectOperation(),
        new GetUserByIdPermissionGrantByIdOperation(),
        new GetUserByIdPermissionGrantCountOperation(),
        new GetUserByIdPermissionGrantsByIdsOperation(),
        new GetUserByIdPermissionGrantsUserOwnedObjectOperation(),
        new ListUserByIdPermissionGrantsOperation(),
        new RestoreUserByIdPermissionGrantByIdOperation(),
        new UpdateUserByIdPermissionGrantByIdOperation(),
        new ValidateUserByIdPermissionGrantsPropertyOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CheckUserByIdPermissionGrantByIdMemberGroupRequestModel),
        typeof(CheckUserByIdPermissionGrantByIdMemberObjectRequestModel),
        typeof(GetUserByIdPermissionGrantByIdMemberGroupRequestModel),
        typeof(GetUserByIdPermissionGrantByIdMemberObjectRequestModel),
        typeof(GetUserByIdPermissionGrantsByIdsRequestModel),
        typeof(GetUserByIdPermissionGrantsUserOwnedObjectRequestModel),
        typeof(ValidateUserByIdPermissionGrantsPropertyRequestModel)
    };
}
