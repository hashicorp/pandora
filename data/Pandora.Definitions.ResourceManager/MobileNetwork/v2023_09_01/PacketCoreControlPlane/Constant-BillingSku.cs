// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2023_09_01.PacketCoreControlPlane;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BillingSkuConstant
{
    [Description("G5")]
    GFive,

    [Description("G1")]
    GOne,

    [Description("G10")]
    GOneZero,

    [Description("G2")]
    GTwo,

    [Description("G0")]
    GZero,
}
