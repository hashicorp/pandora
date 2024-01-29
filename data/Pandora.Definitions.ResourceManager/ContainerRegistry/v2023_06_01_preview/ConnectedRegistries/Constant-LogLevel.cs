// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2023_06_01_preview.ConnectedRegistries;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LogLevelConstant
{
    [Description("Debug")]
    Debug,

    [Description("Error")]
    Error,

    [Description("Information")]
    Information,

    [Description("None")]
    None,

    [Description("Warning")]
    Warning,
}
