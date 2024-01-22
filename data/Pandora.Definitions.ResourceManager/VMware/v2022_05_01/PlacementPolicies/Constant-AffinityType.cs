// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.VMware.v2022_05_01.PlacementPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AffinityTypeConstant
{
    [Description("Affinity")]
    Affinity,

    [Description("AntiAffinity")]
    AntiAffinity,
}
