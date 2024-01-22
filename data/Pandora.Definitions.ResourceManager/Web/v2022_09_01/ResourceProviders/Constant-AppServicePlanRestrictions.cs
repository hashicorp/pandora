// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.ResourceProviders;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AppServicePlanRestrictionsConstant
{
    [Description("Basic")]
    Basic,

    [Description("Free")]
    Free,

    [Description("None")]
    None,

    [Description("Premium")]
    Premium,

    [Description("Shared")]
    Shared,

    [Description("Standard")]
    Standard,
}
