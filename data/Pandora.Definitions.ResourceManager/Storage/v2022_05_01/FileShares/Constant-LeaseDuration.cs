// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Storage.v2022_05_01.FileShares;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LeaseDurationConstant
{
    [Description("Fixed")]
    Fixed,

    [Description("Infinite")]
    Infinite,
}
