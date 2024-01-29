// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Redis.v2022_06_01.Redis;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RebootTypeConstant
{
    [Description("AllNodes")]
    AllNodes,

    [Description("PrimaryNode")]
    PrimaryNode,

    [Description("SecondaryNode")]
    SecondaryNode,
}
