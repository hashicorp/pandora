// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2022_01_01.NodeType;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AccessConstant
{
    [Description("allow")]
    Allow,

    [Description("deny")]
    Deny,
}
