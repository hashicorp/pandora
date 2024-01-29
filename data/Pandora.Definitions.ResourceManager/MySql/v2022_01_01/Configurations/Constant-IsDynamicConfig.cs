// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MySql.v2022_01_01.Configurations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IsDynamicConfigConstant
{
    [Description("False")]
    False,

    [Description("True")]
    True,
}
