// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSql.v2023_03_01_preview.Servers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CreateModeForUpdateConstant
{
    [Description("Default")]
    Default,

    [Description("Update")]
    Update,
}
