// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2019_06_01_preview.Runs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OSConstant
{
    [Description("Linux")]
    Linux,

    [Description("Windows")]
    Windows,
}
