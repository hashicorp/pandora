// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ServiceFabric.v2021_06_01.Application;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RollingUpgradeModeConstant
{
    [Description("Invalid")]
    Invalid,

    [Description("Monitored")]
    Monitored,

    [Description("UnmonitoredAuto")]
    UnmonitoredAuto,

    [Description("UnmonitoredManual")]
    UnmonitoredManual,
}
