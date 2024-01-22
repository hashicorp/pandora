// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Consumption.v2022_09_01.Lots;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LotSourceConstant
{
    [Description("ConsumptionCommitment")]
    ConsumptionCommitment,

    [Description("PromotionalCredit")]
    PromotionalCredit,

    [Description("PurchasedCredit")]
    PurchasedCredit,
}
