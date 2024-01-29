// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2023_11_01.ContentProductPackages;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SupportTierConstant
{
    [Description("Community")]
    Community,

    [Description("Microsoft")]
    Microsoft,

    [Description("Partner")]
    Partner,
}
