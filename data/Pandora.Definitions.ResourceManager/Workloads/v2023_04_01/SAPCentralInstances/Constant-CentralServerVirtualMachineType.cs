// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Workloads.v2023_04_01.SAPCentralInstances;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CentralServerVirtualMachineTypeConstant
{
    [Description("ASCS")]
    ASCS,

    [Description("ERS")]
    ERS,

    [Description("ERSInactive")]
    ERSInactive,

    [Description("Primary")]
    Primary,

    [Description("Secondary")]
    Secondary,

    [Description("Standby")]
    Standby,

    [Description("Unknown")]
    Unknown,
}
