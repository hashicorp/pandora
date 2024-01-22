// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Workloads.v2023_04_01.SAPVirtualInstances;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SAPHealthStateConstant
{
    [Description("Degraded")]
    Degraded,

    [Description("Healthy")]
    Healthy,

    [Description("Unhealthy")]
    Unhealthy,

    [Description("Unknown")]
    Unknown,
}
