// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSql.v2023_03_01_preview.Servers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ServerHAStateConstant
{
    [Description("CreatingStandby")]
    CreatingStandby,

    [Description("FailingOver")]
    FailingOver,

    [Description("Healthy")]
    Healthy,

    [Description("NotEnabled")]
    NotEnabled,

    [Description("RemovingStandby")]
    RemovingStandby,

    [Description("ReplicatingData")]
    ReplicatingData,
}
