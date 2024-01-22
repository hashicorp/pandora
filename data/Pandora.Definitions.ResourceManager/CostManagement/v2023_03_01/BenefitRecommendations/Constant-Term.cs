// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2023_03_01.BenefitRecommendations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TermConstant
{
    [Description("P1Y")]
    POneY,

    [Description("P3Y")]
    PThreeY,
}
