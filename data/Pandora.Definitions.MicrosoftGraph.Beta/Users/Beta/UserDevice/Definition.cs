// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserDevice;

internal class Definition : ResourceDefinition
{
    public string Name => "UserDevice";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckUserByIdDeviceByIdMemberGroupOperation(),
        new CheckUserByIdDeviceByIdMemberObjectOperation(),
        new CreateUserByIdDeviceOperation(),
        new DeleteUserByIdDeviceByIdOperation(),
        new GetUserByIdDeviceByIdMemberGroupOperation(),
        new GetUserByIdDeviceByIdMemberObjectOperation(),
        new GetUserByIdDeviceByIdOperation(),
        new GetUserByIdDeviceCountOperation(),
        new GetUserByIdDevicesByIdsOperation(),
        new GetUserByIdDevicesUserOwnedObjectOperation(),
        new ListUserByIdDevicesOperation(),
        new RestoreUserByIdDeviceByIdOperation(),
        new UpdateUserByIdDeviceByIdOperation(),
        new ValidateUserByIdDevicesPropertyOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CheckUserByIdDeviceByIdMemberGroupRequestModel),
        typeof(CheckUserByIdDeviceByIdMemberObjectRequestModel),
        typeof(GetUserByIdDeviceByIdMemberGroupRequestModel),
        typeof(GetUserByIdDeviceByIdMemberObjectRequestModel),
        typeof(GetUserByIdDevicesByIdsRequestModel),
        typeof(GetUserByIdDevicesUserOwnedObjectRequestModel),
        typeof(ValidateUserByIdDevicesPropertyRequestModel)
    };
}
