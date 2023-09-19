// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeManagedDevice;

internal class Definition : ResourceDefinition
{
    public string Name => "MeManagedDevice";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeManagedDeviceByIdBypassActivationLockOperation(),
        new CreateMeManagedDeviceByIdCleanWindowsDeviceOperation(),
        new CreateMeManagedDeviceByIdDeleteUserFromSharedAppleDeviceOperation(),
        new CreateMeManagedDeviceByIdDisableLostModeOperation(),
        new CreateMeManagedDeviceByIdLocateDeviceOperation(),
        new CreateMeManagedDeviceByIdLogoutSharedAppleDeviceActiveUserOperation(),
        new CreateMeManagedDeviceByIdRebootNowOperation(),
        new CreateMeManagedDeviceByIdRecoverPasscodeOperation(),
        new CreateMeManagedDeviceByIdRemoteLockOperation(),
        new CreateMeManagedDeviceByIdRequestRemoteAssistanceOperation(),
        new CreateMeManagedDeviceByIdResetPasscodeOperation(),
        new CreateMeManagedDeviceByIdRetireOperation(),
        new CreateMeManagedDeviceByIdShutDownOperation(),
        new CreateMeManagedDeviceByIdSyncDeviceOperation(),
        new CreateMeManagedDeviceByIdWindowsDefenderScanOperation(),
        new CreateMeManagedDeviceByIdWindowsDefenderUpdateSignatureOperation(),
        new CreateMeManagedDeviceByIdWipeOperation(),
        new CreateMeManagedDeviceOperation(),
        new DeleteMeManagedDeviceByIdOperation(),
        new GetMeManagedDeviceByIdOperation(),
        new GetMeManagedDeviceCountOperation(),
        new ListMeManagedDevicesOperation(),
        new UpdateMeManagedDeviceByIdOperation(),
        new UpdateMeManagedDeviceByIdWindowsDeviceAccountOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeManagedDeviceByIdCleanWindowsDeviceRequestModel),
        typeof(CreateMeManagedDeviceByIdDeleteUserFromSharedAppleDeviceRequestModel),
        typeof(CreateMeManagedDeviceByIdWindowsDefenderScanRequestModel),
        typeof(CreateMeManagedDeviceByIdWipeRequestModel),
        typeof(UpdateMeManagedDeviceByIdWindowsDeviceAccountRequestModel)
    };
}
