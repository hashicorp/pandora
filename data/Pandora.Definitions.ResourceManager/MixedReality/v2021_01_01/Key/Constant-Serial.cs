// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MixedReality.v2021_01_01.Key;

[ConstantType(ConstantTypeAttribute.ConstantType.Integer)]
internal enum SerialConstant
{
    [Description("1")]
    One,

    [Description("2")]
    Two,
}
