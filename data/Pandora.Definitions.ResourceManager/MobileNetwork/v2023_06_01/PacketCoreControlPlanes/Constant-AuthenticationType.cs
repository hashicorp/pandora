// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2023_06_01.PacketCoreControlPlanes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AuthenticationTypeConstant
{
    [Description("AAD")]
    AAD,

    [Description("Password")]
    Password,
}
