// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Search.v2022_09_01.AdminKeys;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AdminKeyKindConstant
{
    [Description("primary")]
    Primary,

    [Description("secondary")]
    Secondary,
}
