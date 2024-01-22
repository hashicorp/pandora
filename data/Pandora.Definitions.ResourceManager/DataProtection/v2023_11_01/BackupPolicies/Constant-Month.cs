// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataProtection.v2023_11_01.BackupPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MonthConstant
{
    [Description("April")]
    April,

    [Description("August")]
    August,

    [Description("December")]
    December,

    [Description("February")]
    February,

    [Description("January")]
    January,

    [Description("July")]
    July,

    [Description("June")]
    June,

    [Description("March")]
    March,

    [Description("May")]
    May,

    [Description("November")]
    November,

    [Description("October")]
    October,

    [Description("September")]
    September,
}
