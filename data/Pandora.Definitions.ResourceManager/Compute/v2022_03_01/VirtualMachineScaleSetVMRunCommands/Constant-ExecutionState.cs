// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_01.VirtualMachineScaleSetVMRunCommands;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ExecutionStateConstant
{
    [Description("Canceled")]
    Canceled,

    [Description("Failed")]
    Failed,

    [Description("Pending")]
    Pending,

    [Description("Running")]
    Running,

    [Description("Succeeded")]
    Succeeded,

    [Description("TimedOut")]
    TimedOut,

    [Description("Unknown")]
    Unknown,
}
