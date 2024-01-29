// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Media.v2022_08_01.LiveEvents;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StretchModeConstant
{
    [Description("AutoFit")]
    AutoFit,

    [Description("AutoSize")]
    AutoSize,

    [Description("None")]
    None,
}
