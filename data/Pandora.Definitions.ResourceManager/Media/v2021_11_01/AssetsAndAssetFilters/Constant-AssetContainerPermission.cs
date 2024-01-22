// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Media.v2021_11_01.AssetsAndAssetFilters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AssetContainerPermissionConstant
{
    [Description("Read")]
    Read,

    [Description("ReadWrite")]
    ReadWrite,

    [Description("ReadWriteDelete")]
    ReadWriteDelete,
}
