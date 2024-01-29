// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSql.v2023_03_01_preview.Replicas;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AzureManagedDiskPerformanceTiersConstant
{
    [Description("P80")]
    PEightZero,

    [Description("P50")]
    PFiveZero,

    [Description("P4")]
    PFour,

    [Description("P40")]
    PFourZero,

    [Description("P1")]
    POne,

    [Description("P15")]
    POneFive,

    [Description("P10")]
    POneZero,

    [Description("P70")]
    PSevenZero,

    [Description("P6")]
    PSix,

    [Description("P60")]
    PSixZero,

    [Description("P3")]
    PThree,

    [Description("P30")]
    PThreeZero,

    [Description("P2")]
    PTwo,

    [Description("P20")]
    PTwoZero,
}
