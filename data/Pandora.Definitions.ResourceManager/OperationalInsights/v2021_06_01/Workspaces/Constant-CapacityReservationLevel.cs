// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2021_06_01.Workspaces;

[ConstantType(ConstantTypeAttribute.ConstantType.Integer)]
internal enum CapacityReservationLevelConstant
{
    [Description("500")]
    FiveHundred,

    [Description("5000")]
    FiveThousand,

    [Description("400")]
    FourHundred,

    [Description("100")]
    OneHundred,

    [Description("1000")]
    OneThousand,

    [Description("300")]
    ThreeHundred,

    [Description("200")]
    TwoHundred,

    [Description("2000")]
    TwoThousand,
}
