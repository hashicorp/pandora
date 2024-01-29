// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2022_10_01.Tables;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TablePlanEnumConstant
{
    [Description("Analytics")]
    Analytics,

    [Description("Basic")]
    Basic,
}
