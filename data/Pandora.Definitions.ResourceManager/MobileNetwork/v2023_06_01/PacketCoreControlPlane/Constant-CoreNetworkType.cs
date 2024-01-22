// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2023_06_01.PacketCoreControlPlane;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CoreNetworkTypeConstant
{
    [Description("EPC")]
    EPC,

    [Description("EPC + 5GC")]
    EPCPositiveFiveGC,

    [Description("5GC")]
    FiveGC,
}
