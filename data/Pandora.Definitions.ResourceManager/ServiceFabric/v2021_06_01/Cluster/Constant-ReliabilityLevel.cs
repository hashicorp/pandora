// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ServiceFabric.v2021_06_01.Cluster;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ReliabilityLevelConstant
{
    [Description("Bronze")]
    Bronze,

    [Description("Gold")]
    Gold,

    [Description("None")]
    None,

    [Description("Platinum")]
    Platinum,

    [Description("Silver")]
    Silver,
}
