// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MySql.v2021_05_01.Servers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum HighAvailabilityStateConstant
{
    [Description("CreatingStandby")]
    CreatingStandby,

    [Description("FailingOver")]
    FailingOver,

    [Description("Healthy")]
    Healthy,

    [Description("NotEnabled")]
    NotEnabled,

    [Description("RemovingStandby")]
    RemovingStandby,
}
