// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2015_05_01.AnalyticsItemsAPIs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ItemScopeConstant
{
    [Description("shared")]
    Shared,

    [Description("user")]
    User,
}
