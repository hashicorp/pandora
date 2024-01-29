// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2023_03_01.ProximityPlacementGroups;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProximityPlacementGroupTypeConstant
{
    [Description("Standard")]
    Standard,

    [Description("Ultra")]
    Ultra,
}
