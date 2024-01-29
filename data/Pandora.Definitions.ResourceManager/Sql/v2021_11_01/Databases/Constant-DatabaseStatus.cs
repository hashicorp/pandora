// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.Databases;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DatabaseStatusConstant
{
    [Description("AutoClosed")]
    AutoClosed,

    [Description("Copying")]
    Copying,

    [Description("Creating")]
    Creating,

    [Description("Disabled")]
    Disabled,

    [Description("EmergencyMode")]
    EmergencyMode,

    [Description("Inaccessible")]
    Inaccessible,

    [Description("Offline")]
    Offline,

    [Description("OfflineChangingDwPerformanceTiers")]
    OfflineChangingDwPerformanceTiers,

    [Description("OfflineSecondary")]
    OfflineSecondary,

    [Description("Online")]
    Online,

    [Description("OnlineChangingDwPerformanceTiers")]
    OnlineChangingDwPerformanceTiers,

    [Description("Paused")]
    Paused,

    [Description("Pausing")]
    Pausing,

    [Description("Recovering")]
    Recovering,

    [Description("RecoveryPending")]
    RecoveryPending,

    [Description("Restoring")]
    Restoring,

    [Description("Resuming")]
    Resuming,

    [Description("Scaling")]
    Scaling,

    [Description("Shutdown")]
    Shutdown,

    [Description("Standby")]
    Standby,

    [Description("Starting")]
    Starting,

    [Description("Stopped")]
    Stopped,

    [Description("Stopping")]
    Stopping,

    [Description("Suspect")]
    Suspect,
}
