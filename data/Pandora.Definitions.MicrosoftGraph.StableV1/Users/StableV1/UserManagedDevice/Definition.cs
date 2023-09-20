// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserManagedDevice;

internal class Definition : ResourceDefinition
{
    public string Name => "UserManagedDevice";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdManagedDeviceByIdBypassActivationLockOperation(),
        new CreateUserByIdManagedDeviceByIdCleanWindowsDeviceOperation(),
        new CreateUserByIdManagedDeviceByIdDeleteUserFromSharedAppleDeviceOperation(),
        new CreateUserByIdManagedDeviceByIdDisableLostModeOperation(),
        new CreateUserByIdManagedDeviceByIdLocateDeviceOperation(),
        new CreateUserByIdManagedDeviceByIdLogoutSharedAppleDeviceActiveUserOperation(),
        new CreateUserByIdManagedDeviceByIdRebootNowOperation(),
        new CreateUserByIdManagedDeviceByIdRecoverPasscodeOperation(),
        new CreateUserByIdManagedDeviceByIdRemoteLockOperation(),
        new CreateUserByIdManagedDeviceByIdRequestRemoteAssistanceOperation(),
        new CreateUserByIdManagedDeviceByIdResetPasscodeOperation(),
        new CreateUserByIdManagedDeviceByIdRetireOperation(),
        new CreateUserByIdManagedDeviceByIdShutDownOperation(),
        new CreateUserByIdManagedDeviceByIdSyncDeviceOperation(),
        new CreateUserByIdManagedDeviceByIdWindowsDefenderScanOperation(),
        new CreateUserByIdManagedDeviceByIdWindowsDefenderUpdateSignatureOperation(),
        new CreateUserByIdManagedDeviceByIdWipeOperation(),
        new CreateUserByIdManagedDeviceOperation(),
        new DeleteUserByIdManagedDeviceByIdOperation(),
        new GetUserByIdManagedDeviceByIdOperation(),
        new GetUserByIdManagedDeviceCountOperation(),
        new ListUserByIdManagedDevicesOperation(),
        new UpdateUserByIdManagedDeviceByIdOperation(),
        new UpdateUserByIdManagedDeviceByIdWindowsDeviceAccountOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdManagedDeviceByIdCleanWindowsDeviceRequestModel),
        typeof(CreateUserByIdManagedDeviceByIdDeleteUserFromSharedAppleDeviceRequestModel),
        typeof(CreateUserByIdManagedDeviceByIdWindowsDefenderScanRequestModel),
        typeof(CreateUserByIdManagedDeviceByIdWipeRequestModel),
        typeof(UpdateUserByIdManagedDeviceByIdWindowsDeviceAccountRequestModel)
    };
}
