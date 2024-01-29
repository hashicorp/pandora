// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2022_11_01.PacketCoreControlPlaneVersion;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PlatformTypeConstant
{
    [Description("AKS-HCI")]
    AKSNegativeHCI,

    [Description("3P-AZURE-STACK-HCI")]
    ThreePNegativeAZURENegativeSTACKNegativeHCI,
}
