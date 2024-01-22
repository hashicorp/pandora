// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerService.v2023_04_02_preview.ManagedClusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum UpdateModeConstant
{
    [Description("Auto")]
    Auto,

    [Description("Initial")]
    Initial,

    [Description("Off")]
    Off,

    [Description("Recreate")]
    Recreate,
}
