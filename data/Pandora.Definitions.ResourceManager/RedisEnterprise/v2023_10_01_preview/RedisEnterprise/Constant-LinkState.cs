// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RedisEnterprise.v2023_10_01_preview.RedisEnterprise;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LinkStateConstant
{
    [Description("LinkFailed")]
    LinkFailed,

    [Description("Linked")]
    Linked,

    [Description("Linking")]
    Linking,

    [Description("UnlinkFailed")]
    UnlinkFailed,

    [Description("Unlinking")]
    Unlinking,
}
