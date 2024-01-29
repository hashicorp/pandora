// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2023_03_01.VirtualMachineScaleSetVMs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MaintenanceOperationResultCodeTypesConstant
{
    [Description("MaintenanceAborted")]
    MaintenanceAborted,

    [Description("MaintenanceCompleted")]
    MaintenanceCompleted,

    [Description("None")]
    None,

    [Description("RetryLater")]
    RetryLater,
}
