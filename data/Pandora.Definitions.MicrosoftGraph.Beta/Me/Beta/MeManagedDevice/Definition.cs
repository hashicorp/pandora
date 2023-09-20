// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeManagedDevice;

internal class Definition : ResourceDefinition
{
    public string Name => "MeManagedDevice";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeManagedDeviceBulkReprovisionCloudPCOperation(),
        new CreateMeManagedDeviceBulkRestoreCloudPCOperation(),
        new CreateMeManagedDeviceBulkSetCloudPCReviewStatuOperation(),
        new CreateMeManagedDeviceByIdActivateDeviceEsimOperation(),
        new CreateMeManagedDeviceByIdBypassActivationLockOperation(),
        new CreateMeManagedDeviceByIdCleanWindowsDeviceOperation(),
        new CreateMeManagedDeviceByIdCreateDeviceLogCollectionRequestOperation(),
        new CreateMeManagedDeviceByIdDeleteUserFromSharedAppleDeviceOperation(),
        new CreateMeManagedDeviceByIdDeprovisionOperation(),
        new CreateMeManagedDeviceByIdDisableLostModeOperation(),
        new CreateMeManagedDeviceByIdDisableOperation(),
        new CreateMeManagedDeviceByIdEnableLostModeOperation(),
        new CreateMeManagedDeviceByIdEnrollNowActionOperation(),
        new CreateMeManagedDeviceByIdInitiateMobileDeviceManagementKeyRecoveryOperation(),
        new CreateMeManagedDeviceByIdInitiateOnDemandProactiveRemediationOperation(),
        new CreateMeManagedDeviceByIdLocateDeviceOperation(),
        new CreateMeManagedDeviceByIdLogoutSharedAppleDeviceActiveUserOperation(),
        new CreateMeManagedDeviceByIdOverrideComplianceStateOperation(),
        new CreateMeManagedDeviceByIdPlayLostModeSoundOperation(),
        new CreateMeManagedDeviceByIdRebootNowOperation(),
        new CreateMeManagedDeviceByIdRecoverPasscodeOperation(),
        new CreateMeManagedDeviceByIdReenableOperation(),
        new CreateMeManagedDeviceByIdRemoteLockOperation(),
        new CreateMeManagedDeviceByIdReprovisionCloudPCOperation(),
        new CreateMeManagedDeviceByIdRequestRemoteAssistanceOperation(),
        new CreateMeManagedDeviceByIdResetPasscodeOperation(),
        new CreateMeManagedDeviceByIdResizeCloudPCOperation(),
        new CreateMeManagedDeviceByIdRetireOperation(),
        new CreateMeManagedDeviceByIdRevokeAppleVppLicensOperation(),
        new CreateMeManagedDeviceByIdRotateBitLockerKeyOperation(),
        new CreateMeManagedDeviceByIdRotateFileVaultKeyOperation(),
        new CreateMeManagedDeviceByIdRotateLocalAdminPasswordOperation(),
        new CreateMeManagedDeviceByIdSendCustomNotificationToCompanyPortalOperation(),
        new CreateMeManagedDeviceByIdShutDownOperation(),
        new CreateMeManagedDeviceByIdSyncDeviceOperation(),
        new CreateMeManagedDeviceByIdTriggerConfigurationManagerActionOperation(),
        new CreateMeManagedDeviceByIdWindowsDefenderScanOperation(),
        new CreateMeManagedDeviceByIdWindowsDefenderUpdateSignatureOperation(),
        new CreateMeManagedDeviceByIdWipeOperation(),
        new CreateMeManagedDeviceDownloadAppDiagnosticOperation(),
        new CreateMeManagedDeviceExecuteActionOperation(),
        new CreateMeManagedDeviceMoveDevicesToOUOperation(),
        new CreateMeManagedDeviceOperation(),
        new DeleteMeManagedDeviceByIdOperation(),
        new GetMeManagedDeviceByIdOperation(),
        new GetMeManagedDeviceCountOperation(),
        new ListMeManagedDevicesOperation(),
        new RemoveMeManagedDeviceByIdDeviceFirmwareConfigurationInterfaceManagementOperation(),
        new RestoreMeManagedDeviceByIdCloudPCOperation(),
        new SetMeManagedDeviceByIdCloudPCReviewStatuOperation(),
        new SetMeManagedDeviceByIdDeviceNameOperation(),
        new UpdateMeManagedDeviceByIdOperation(),
        new UpdateMeManagedDeviceByIdWindowsDeviceAccountOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CreateMeManagedDeviceBulkRestoreCloudPCRequestTimeRangeConstant),
        typeof(CreateMeManagedDeviceByIdOverrideComplianceStateRequestComplianceStateConstant),
        typeof(CreateMeManagedDeviceByIdWipeRequestObliterationBehaviorConstant),
        typeof(CreateMeManagedDeviceExecuteActionRequestActionNameConstant)
    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeManagedDeviceBulkReprovisionCloudPCRequestModel),
        typeof(CreateMeManagedDeviceBulkRestoreCloudPCRequestModel),
        typeof(CreateMeManagedDeviceBulkSetCloudPCReviewStatuRequestModel),
        typeof(CreateMeManagedDeviceByIdActivateDeviceEsimRequestModel),
        typeof(CreateMeManagedDeviceByIdCleanWindowsDeviceRequestModel),
        typeof(CreateMeManagedDeviceByIdCreateDeviceLogCollectionRequestRequestModel),
        typeof(CreateMeManagedDeviceByIdDeleteUserFromSharedAppleDeviceRequestModel),
        typeof(CreateMeManagedDeviceByIdDeprovisionRequestModel),
        typeof(CreateMeManagedDeviceByIdEnableLostModeRequestModel),
        typeof(CreateMeManagedDeviceByIdInitiateOnDemandProactiveRemediationRequestModel),
        typeof(CreateMeManagedDeviceByIdOverrideComplianceStateRequestModel),
        typeof(CreateMeManagedDeviceByIdPlayLostModeSoundRequestModel),
        typeof(CreateMeManagedDeviceByIdResizeCloudPCRequestModel),
        typeof(CreateMeManagedDeviceByIdSendCustomNotificationToCompanyPortalRequestModel),
        typeof(CreateMeManagedDeviceByIdTriggerConfigurationManagerActionRequestModel),
        typeof(CreateMeManagedDeviceByIdWindowsDefenderScanRequestModel),
        typeof(CreateMeManagedDeviceByIdWipeRequestModel),
        typeof(CreateMeManagedDeviceDownloadAppDiagnosticRequestModel),
        typeof(CreateMeManagedDeviceExecuteActionRequestModel),
        typeof(CreateMeManagedDeviceMoveDevicesToOURequestModel),
        typeof(RestoreMeManagedDeviceByIdCloudPCRequestModel),
        typeof(SetMeManagedDeviceByIdCloudPCReviewStatuRequestModel),
        typeof(SetMeManagedDeviceByIdDeviceNameRequestModel),
        typeof(UpdateMeManagedDeviceByIdWindowsDeviceAccountRequestModel)
    };
}
