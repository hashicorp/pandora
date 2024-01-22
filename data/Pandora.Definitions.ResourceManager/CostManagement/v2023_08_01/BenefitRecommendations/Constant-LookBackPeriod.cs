// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2023_08_01.BenefitRecommendations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LookBackPeriodConstant
{
    [Description("Last7Days")]
    LastSevenDays,

    [Description("Last60Days")]
    LastSixZeroDays,

    [Description("Last30Days")]
    LastThreeZeroDays,
}
