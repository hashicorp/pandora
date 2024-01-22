// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.AppServicePlans;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SiteAvailabilityStateConstant
{
    [Description("DisasterRecoveryMode")]
    DisasterRecoveryMode,

    [Description("Limited")]
    Limited,

    [Description("Normal")]
    Normal,
}
