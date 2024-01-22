// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Resources.v2021_06_01.PolicyDefinitions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PolicyTypeConstant
{
    [Description("BuiltIn")]
    BuiltIn,

    [Description("Custom")]
    Custom,

    [Description("NotSpecified")]
    NotSpecified,

    [Description("Static")]
    Static,
}
