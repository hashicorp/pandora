// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeManagedDevice;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CreateMeManagedDeviceExecuteActionRequestActionNameConstant
{
    [Description("Retire")]
    @retire,

    [Description("Delete")]
    @delete,

    [Description("FullScan")]
    @fullScan,

    [Description("QuickScan")]
    @quickScan,

    [Description("SignatureUpdate")]
    @signatureUpdate,

    [Description("Wipe")]
    @wipe,

    [Description("CustomTextNotification")]
    @customTextNotification,

    [Description("RebootNow")]
    @rebootNow,

    [Description("SetDeviceName")]
    @setDeviceName,

    [Description("SyncDevice")]
    @syncDevice,

    [Description("Deprovision")]
    @deprovision,

    [Description("Disable")]
    @disable,

    [Description("Reenable")]
    @reenable,

    [Description("MoveDeviceToOrganizationalUnit")]
    @moveDeviceToOrganizationalUnit,

    [Description("ActivateDeviceEsim")]
    @activateDeviceEsim,

    [Description("CollectDiagnostics")]
    @collectDiagnostics,

    [Description("InitiateMobileDeviceManagementKeyRecovery")]
    @initiateMobileDeviceManagementKeyRecovery,

    [Description("InitiateOnDemandProactiveRemediation")]
    @initiateOnDemandProactiveRemediation,
}
