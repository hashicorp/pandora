// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerService.v2019_08_01.AgentPools;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ContainerServiceOSTypesConstant
{
    [Description("Linux")]
    Linux,

    [Description("Windows")]
    Windows,
}
