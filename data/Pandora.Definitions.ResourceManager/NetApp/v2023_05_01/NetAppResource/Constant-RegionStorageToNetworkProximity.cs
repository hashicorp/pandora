// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NetApp.v2023_05_01.NetAppResource;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RegionStorageToNetworkProximityConstant
{
    [Description("AcrossT2")]
    AcrossTTwo,

    [Description("Default")]
    Default,

    [Description("T1")]
    TOne,

    [Description("T1AndAcrossT2")]
    TOneAndAcrossTTwo,

    [Description("T1AndT2")]
    TOneAndTTwo,

    [Description("T1AndT2AndAcrossT2")]
    TOneAndTTwoAndAcrossTTwo,

    [Description("T2")]
    TTwo,

    [Description("T2AndAcrossT2")]
    TTwoAndAcrossTTwo,
}
