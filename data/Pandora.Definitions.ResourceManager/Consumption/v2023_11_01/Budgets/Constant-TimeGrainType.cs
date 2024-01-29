// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Consumption.v2023_11_01.Budgets;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TimeGrainTypeConstant
{
    [Description("Annually")]
    Annually,

    [Description("BillingAnnual")]
    BillingAnnual,

    [Description("BillingMonth")]
    BillingMonth,

    [Description("BillingQuarter")]
    BillingQuarter,

    [Description("Monthly")]
    Monthly,

    [Description("Quarterly")]
    Quarterly,
}
