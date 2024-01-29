// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_04_01.CustomIPPrefixes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CustomIPPrefixTypeConstant
{
    [Description("Child")]
    Child,

    [Description("Parent")]
    Parent,

    [Description("Singular")]
    Singular,
}
