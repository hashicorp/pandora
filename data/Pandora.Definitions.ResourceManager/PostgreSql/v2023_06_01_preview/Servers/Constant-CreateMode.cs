// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSql.v2023_06_01_preview.Servers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CreateModeConstant
{
    [Description("Create")]
    Create,

    [Description("Default")]
    Default,

    [Description("GeoRestore")]
    GeoRestore,

    [Description("PointInTimeRestore")]
    PointInTimeRestore,

    [Description("Replica")]
    Replica,

    [Description("ReviveDropped")]
    ReviveDropped,

    [Description("Update")]
    Update,
}
