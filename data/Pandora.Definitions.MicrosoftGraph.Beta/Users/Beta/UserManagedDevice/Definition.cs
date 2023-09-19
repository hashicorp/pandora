// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserManagedDevice;

internal class Definition : ResourceDefinition
{
    public string Name => "UserManagedDevice";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdManagedDeviceBulkReprovisionCloudPCOperation(),
        new CreateUserByIdManagedDeviceBulkRestoreCloudPCOperation(),
        new CreateUserByIdManagedDeviceBulkSetCloudPCReviewStatuOperation(),
        new CreateUserByIdManagedDeviceByIdActivateDeviceEsimOperation(),
        new CreateUserByIdManagedDeviceByIdBypassActivationLockOperation(),
        new CreateUserByIdManagedDeviceByIdCleanWindowsDeviceOperation(),
        new CreateUserByIdManagedDeviceByIdCreateDeviceLogCollectionRequestOperation(),
        new CreateUserByIdManagedDeviceByIdDeleteUserFromSharedAppleDeviceOperation(),
        new CreateUserByIdManagedDeviceByIdDeprovisionOperation(),
        new CreateUserByIdManagedDeviceByIdDisableLostModeOperation(),
        new CreateUserByIdManagedDeviceByIdDisableOperation(),
        new CreateUserByIdManagedDeviceByIdEnableLostModeOperation(),
        new CreateUserByIdManagedDeviceByIdEnrollNowActionOperation(),
        new CreateUserByIdManagedDeviceByIdInitiateMobileDeviceManagementKeyRecoveryOperation(),
        new CreateUserByIdManagedDeviceByIdInitiateOnDemandProactiveRemediationOperation(),
        new CreateUserByIdManagedDeviceByIdLocateDeviceOperation(),
        new CreateUserByIdManagedDeviceByIdLogoutSharedAppleDeviceActiveUserOperation(),
        new CreateUserByIdManagedDeviceByIdOverrideComplianceStateOperation(),
        new CreateUserByIdManagedDeviceByIdPlayLostModeSoundOperation(),
        new CreateUserByIdManagedDeviceByIdRebootNowOperation(),
        new CreateUserByIdManagedDeviceByIdRecoverPasscodeOperation(),
        new CreateUserByIdManagedDeviceByIdReenableOperation(),
        new CreateUserByIdManagedDeviceByIdRemoteLockOperation(),
        new CreateUserByIdManagedDeviceByIdReprovisionCloudPCOperation(),
        new CreateUserByIdManagedDeviceByIdRequestRemoteAssistanceOperation(),
        new CreateUserByIdManagedDeviceByIdResetPasscodeOperation(),
        new CreateUserByIdManagedDeviceByIdResizeCloudPCOperation(),
        new CreateUserByIdManagedDeviceByIdRetireOperation(),
        new CreateUserByIdManagedDeviceByIdRevokeAppleVppLicensOperation(),
        new CreateUserByIdManagedDeviceByIdRotateBitLockerKeyOperation(),
        new CreateUserByIdManagedDeviceByIdRotateFileVaultKeyOperation(),
        new CreateUserByIdManagedDeviceByIdRotateLocalAdminPasswordOperation(),
        new CreateUserByIdManagedDeviceByIdSendCustomNotificationToCompanyPortalOperation(),
        new CreateUserByIdManagedDeviceByIdShutDownOperation(),
        new CreateUserByIdManagedDeviceByIdSyncDeviceOperation(),
        new CreateUserByIdManagedDeviceByIdTriggerConfigurationManagerActionOperation(),
        new CreateUserByIdManagedDeviceByIdWindowsDefenderScanOperation(),
        new CreateUserByIdManagedDeviceByIdWindowsDefenderUpdateSignatureOperation(),
        new CreateUserByIdManagedDeviceByIdWipeOperation(),
        new CreateUserByIdManagedDeviceDownloadAppDiagnosticOperation(),
        new CreateUserByIdManagedDeviceExecuteActionOperation(),
        new CreateUserByIdManagedDeviceMoveDevicesToOUOperation(),
        new CreateUserByIdManagedDeviceOperation(),
        new DeleteUserByIdManagedDeviceByIdOperation(),
        new GetUserByIdManagedDeviceByIdOperation(),
        new GetUserByIdManagedDeviceCountOperation(),
        new ListUserByIdManagedDevicesOperation(),
        new RemoveUserByIdManagedDeviceByIdDeviceFirmwareConfigurationInterfaceManagementOperation(),
        new RestoreUserByIdManagedDeviceByIdCloudPCOperation(),
        new SetUserByIdManagedDeviceByIdCloudPCReviewStatuOperation(),
        new SetUserByIdManagedDeviceByIdDeviceNameOperation(),
        new UpdateUserByIdManagedDeviceByIdOperation(),
        new UpdateUserByIdManagedDeviceByIdWindowsDeviceAccountOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CreateUserByIdManagedDeviceBulkRestoreCloudPCRequestTimeRangeConstant),
        typeof(CreateUserByIdManagedDeviceByIdOverrideComplianceStateRequestComplianceStateConstant),
        typeof(CreateUserByIdManagedDeviceByIdWipeRequestObliterationBehaviorConstant),
        typeof(CreateUserByIdManagedDeviceExecuteActionRequestActionNameConstant)
    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdManagedDeviceBulkReprovisionCloudPCRequestModel),
        typeof(CreateUserByIdManagedDeviceBulkRestoreCloudPCRequestModel),
        typeof(CreateUserByIdManagedDeviceBulkSetCloudPCReviewStatuRequestModel),
        typeof(CreateUserByIdManagedDeviceByIdActivateDeviceEsimRequestModel),
        typeof(CreateUserByIdManagedDeviceByIdCleanWindowsDeviceRequestModel),
        typeof(CreateUserByIdManagedDeviceByIdCreateDeviceLogCollectionRequestRequestModel),
        typeof(CreateUserByIdManagedDeviceByIdDeleteUserFromSharedAppleDeviceRequestModel),
        typeof(CreateUserByIdManagedDeviceByIdDeprovisionRequestModel),
        typeof(CreateUserByIdManagedDeviceByIdEnableLostModeRequestModel),
        typeof(CreateUserByIdManagedDeviceByIdInitiateOnDemandProactiveRemediationRequestModel),
        typeof(CreateUserByIdManagedDeviceByIdOverrideComplianceStateRequestModel),
        typeof(CreateUserByIdManagedDeviceByIdPlayLostModeSoundRequestModel),
        typeof(CreateUserByIdManagedDeviceByIdResizeCloudPCRequestModel),
        typeof(CreateUserByIdManagedDeviceByIdSendCustomNotificationToCompanyPortalRequestModel),
        typeof(CreateUserByIdManagedDeviceByIdTriggerConfigurationManagerActionRequestModel),
        typeof(CreateUserByIdManagedDeviceByIdWindowsDefenderScanRequestModel),
        typeof(CreateUserByIdManagedDeviceByIdWipeRequestModel),
        typeof(CreateUserByIdManagedDeviceDownloadAppDiagnosticRequestModel),
        typeof(CreateUserByIdManagedDeviceExecuteActionRequestModel),
        typeof(CreateUserByIdManagedDeviceMoveDevicesToOURequestModel),
        typeof(RestoreUserByIdManagedDeviceByIdCloudPCRequestModel),
        typeof(SetUserByIdManagedDeviceByIdCloudPCReviewStatuRequestModel),
        typeof(SetUserByIdManagedDeviceByIdDeviceNameRequestModel),
        typeof(UpdateUserByIdManagedDeviceByIdWindowsDeviceAccountRequestModel)
    };
}
