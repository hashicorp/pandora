// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.FrontDoor.v2022_05_01.WebApplicationFirewallPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SkuNameConstant
{
    [Description("Classic_AzureFrontDoor")]
    ClassicAzureFrontDoor,

    [Description("Premium_AzureFrontDoor")]
    PremiumAzureFrontDoor,

    [Description("Standard_AzureFrontDoor")]
    StandardAzureFrontDoor,
}
