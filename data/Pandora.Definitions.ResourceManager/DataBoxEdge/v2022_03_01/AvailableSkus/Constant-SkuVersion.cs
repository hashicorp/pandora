// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2022_03_01.AvailableSkus;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SkuVersionConstant
{
    [Description("Preview")]
    Preview,

    [Description("Stable")]
    Stable,
}
