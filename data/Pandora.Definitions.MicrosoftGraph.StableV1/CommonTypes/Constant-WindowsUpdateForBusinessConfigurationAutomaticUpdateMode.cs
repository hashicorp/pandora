// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WindowsUpdateForBusinessConfigurationAutomaticUpdateModeConstant
{
    [Description("UserDefined")]
    @userDefined,

    [Description("NotifyDownload")]
    @notifyDownload,

    [Description("AutoInstallAtMaintenanceTime")]
    @autoInstallAtMaintenanceTime,

    [Description("AutoInstallAndRebootAtMaintenanceTime")]
    @autoInstallAndRebootAtMaintenanceTime,

    [Description("AutoInstallAndRebootAtScheduledTime")]
    @autoInstallAndRebootAtScheduledTime,

    [Description("AutoInstallAndRebootWithoutEndUserControl")]
    @autoInstallAndRebootWithoutEndUserControl,
}
