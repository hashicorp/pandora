// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2023_06_01.PacketCoreControlPlane;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum InstallationReasonConstant
{
    [Description("NoAttachedDataNetworks")]
    NoAttachedDataNetworks,

    [Description("NoPacketCoreDataPlane")]
    NoPacketCoreDataPlane,

    [Description("NoSlices")]
    NoSlices,
}
