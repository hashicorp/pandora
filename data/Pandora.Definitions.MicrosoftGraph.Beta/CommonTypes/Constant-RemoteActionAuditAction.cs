// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RemoteActionAuditActionConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("FactoryReset")]
    @factoryReset,

    [Description("RemoveCompanyData")]
    @removeCompanyData,

    [Description("ResetPasscode")]
    @resetPasscode,

    [Description("RemoteLock")]
    @remoteLock,

    [Description("EnableLostMode")]
    @enableLostMode,

    [Description("DisableLostMode")]
    @disableLostMode,

    [Description("LocateDevice")]
    @locateDevice,

    [Description("RebootNow")]
    @rebootNow,

    [Description("RecoverPasscode")]
    @recoverPasscode,

    [Description("CleanWindowsDevice")]
    @cleanWindowsDevice,

    [Description("LogoutSharedAppleDeviceActiveUser")]
    @logoutSharedAppleDeviceActiveUser,

    [Description("QuickScan")]
    @quickScan,

    [Description("FullScan")]
    @fullScan,

    [Description("WindowsDefenderUpdateSignatures")]
    @windowsDefenderUpdateSignatures,

    [Description("FactoryResetKeepEnrollmentData")]
    @factoryResetKeepEnrollmentData,

    [Description("UpdateDeviceAccount")]
    @updateDeviceAccount,

    [Description("AutomaticRedeployment")]
    @automaticRedeployment,

    [Description("ShutDown")]
    @shutDown,

    [Description("RotateBitLockerKeys")]
    @rotateBitLockerKeys,

    [Description("RotateFileVaultKey")]
    @rotateFileVaultKey,

    [Description("GetFileVaultKey")]
    @getFileVaultKey,

    [Description("SetDeviceName")]
    @setDeviceName,

    [Description("ActivateDeviceEsim")]
    @activateDeviceEsim,

    [Description("Deprovision")]
    @deprovision,

    [Description("Disable")]
    @disable,

    [Description("Reenable")]
    @reenable,

    [Description("MoveDeviceToOrganizationalUnit")]
    @moveDeviceToOrganizationalUnit,

    [Description("InitiateMobileDeviceManagementKeyRecovery")]
    @initiateMobileDeviceManagementKeyRecovery,

    [Description("InitiateOnDemandProactiveRemediation")]
    @initiateOnDemandProactiveRemediation,

    [Description("RotateLocalAdminPassword")]
    @rotateLocalAdminPassword,

    [Description("LaunchRemoteHelp")]
    @launchRemoteHelp,

    [Description("RevokeAppleVppLicenses")]
    @revokeAppleVppLicenses,

    [Description("RemoveDeviceFirmwareConfigurationInterfaceManagement")]
    @removeDeviceFirmwareConfigurationInterfaceManagement,
}
