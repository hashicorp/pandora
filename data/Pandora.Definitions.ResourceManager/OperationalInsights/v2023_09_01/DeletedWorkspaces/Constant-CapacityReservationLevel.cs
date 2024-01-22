// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2023_09_01.DeletedWorkspaces;

[ConstantType(ConstantTypeAttribute.ConstantType.Integer)]
internal enum CapacityReservationLevelConstant
{
    [Description("500")]
    FiveHundred,

    [Description("5000")]
    FiveThousand,

    [Description("50000")]
    FiveZeroThousand,

    [Description("400")]
    FourHundred,

    [Description("100")]
    OneHundred,

    [Description("1000")]
    OneThousand,

    [Description("10000")]
    OneZeroThousand,

    [Description("300")]
    ThreeHundred,

    [Description("25000")]
    TwoFiveThousand,

    [Description("200")]
    TwoHundred,

    [Description("2000")]
    TwoThousand,
}
