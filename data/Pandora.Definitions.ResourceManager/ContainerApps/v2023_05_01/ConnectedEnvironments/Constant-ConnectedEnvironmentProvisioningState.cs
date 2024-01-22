// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2023_05_01.ConnectedEnvironments;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ConnectedEnvironmentProvisioningStateConstant
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

    [Description("Waiting")]
    Waiting,
}
