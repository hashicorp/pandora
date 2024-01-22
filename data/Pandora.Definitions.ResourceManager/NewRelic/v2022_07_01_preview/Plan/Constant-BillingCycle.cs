// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NewRelic.v2022_07_01_preview.Plan;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BillingCycleConstant
{
    [Description("MONTHLY")]
    MONTHLY,

    [Description("WEEKLY")]
    WEEKLY,

    [Description("YEARLY")]
    YEARLY,
}
