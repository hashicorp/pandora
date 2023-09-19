// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserChatPermissionGrant;

internal class Definition : ResourceDefinition
{
    public string Name => "UserChatPermissionGrant";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckUserByIdChatByIdPermissionGrantByIdMemberGroupOperation(),
        new CheckUserByIdChatByIdPermissionGrantByIdMemberObjectOperation(),
        new CreateUserByIdChatByIdPermissionGrantOperation(),
        new DeleteUserByIdChatByIdPermissionGrantByIdOperation(),
        new GetUserByIdChatByIdPermissionGrantByIdMemberGroupOperation(),
        new GetUserByIdChatByIdPermissionGrantByIdMemberObjectOperation(),
        new GetUserByIdChatByIdPermissionGrantByIdOperation(),
        new GetUserByIdChatByIdPermissionGrantCountOperation(),
        new GetUserByIdChatByIdPermissionGrantsByIdsOperation(),
        new GetUserByIdChatByIdPermissionGrantsUserOwnedObjectOperation(),
        new ListUserByIdChatByIdPermissionGrantsOperation(),
        new RestoreUserByIdChatByIdPermissionGrantByIdOperation(),
        new UpdateUserByIdChatByIdPermissionGrantByIdOperation(),
        new ValidateUserByIdChatByIdPermissionGrantsPropertyOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CheckUserByIdChatByIdPermissionGrantByIdMemberGroupRequestModel),
        typeof(CheckUserByIdChatByIdPermissionGrantByIdMemberObjectRequestModel),
        typeof(GetUserByIdChatByIdPermissionGrantByIdMemberGroupRequestModel),
        typeof(GetUserByIdChatByIdPermissionGrantByIdMemberObjectRequestModel),
        typeof(GetUserByIdChatByIdPermissionGrantsByIdsRequestModel),
        typeof(GetUserByIdChatByIdPermissionGrantsUserOwnedObjectRequestModel),
        typeof(ValidateUserByIdChatByIdPermissionGrantsPropertyRequestModel)
    };
}
