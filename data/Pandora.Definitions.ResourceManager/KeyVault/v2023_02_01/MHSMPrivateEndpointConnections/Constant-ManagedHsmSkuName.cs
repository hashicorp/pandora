// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.KeyVault.v2023_02_01.MHSMPrivateEndpointConnections;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ManagedHsmSkuNameConstant
{
    [Description("Custom_B6")]
    CustomBSix,

    [Description("Custom_B32")]
    CustomBThreeTwo,

    [Description("Standard_B1")]
    StandardBOne,
}
