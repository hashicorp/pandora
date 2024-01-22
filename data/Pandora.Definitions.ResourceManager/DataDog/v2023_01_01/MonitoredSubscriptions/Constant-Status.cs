// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataDog.v2023_01_01.MonitoredSubscriptions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StatusConstant
{
    [Description("Active")]
    Active,

    [Description("Deleting")]
    Deleting,

    [Description("Failed")]
    Failed,

    [Description("InProgress")]
    InProgress,
}
