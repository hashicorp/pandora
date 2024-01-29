// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_02_01.ProtectionPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MonthOfYearConstant
{
    [Description("April")]
    April,

    [Description("August")]
    August,

    [Description("December")]
    December,

    [Description("February")]
    February,

    [Description("Invalid")]
    Invalid,

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
