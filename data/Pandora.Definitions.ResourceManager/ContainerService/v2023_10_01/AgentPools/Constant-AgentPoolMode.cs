// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerService.v2023_10_01.AgentPools;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AgentPoolModeConstant
{
    [Description("System")]
    System,

    [Description("User")]
    User,
}
