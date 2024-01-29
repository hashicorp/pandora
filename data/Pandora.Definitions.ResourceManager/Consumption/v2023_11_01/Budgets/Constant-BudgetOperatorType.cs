// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Consumption.v2023_11_01.Budgets;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BudgetOperatorTypeConstant
{
    [Description("In")]
    In,
}
