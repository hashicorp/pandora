// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2023_06_01_preview.ConnectedRegistries;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ConnectionStateConstant
{
    [Description("Offline")]
    Offline,

    [Description("Online")]
    Online,

    [Description("Syncing")]
    Syncing,

    [Description("Unhealthy")]
    Unhealthy,
}
