// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_03.GallerySharingUpdate;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SharingUpdateOperationTypesConstant
{
    [Description("Add")]
    Add,

    [Description("EnableCommunity")]
    EnableCommunity,

    [Description("Remove")]
    Remove,

    [Description("Reset")]
    Reset,
}
