// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2023_01_01.Pricings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IsEnabledConstant
{
    [Description("False")]
    False,

    [Description("True")]
    True,
}
