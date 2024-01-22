// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.ApisByTag;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProductStateConstant
{
    [Description("notPublished")]
    NotPublished,

    [Description("published")]
    Published,
}
