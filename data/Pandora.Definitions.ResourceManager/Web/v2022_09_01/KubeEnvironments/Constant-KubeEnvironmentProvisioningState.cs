// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.KubeEnvironments;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KubeEnvironmentProvisioningStateConstant
{
    [Description("Canceled")]
    Canceled,

    [Description("Failed")]
    Failed,

    [Description("InfrastructureSetupComplete")]
    InfrastructureSetupComplete,

    [Description("InfrastructureSetupInProgress")]
    InfrastructureSetupInProgress,

    [Description("InitializationInProgress")]
    InitializationInProgress,

    [Description("ScheduledForDelete")]
    ScheduledForDelete,

    [Description("Succeeded")]
    Succeeded,

    [Description("UpgradeFailed")]
    UpgradeFailed,

    [Description("UpgradeRequested")]
    UpgradeRequested,

    [Description("Waiting")]
    Waiting,
}
