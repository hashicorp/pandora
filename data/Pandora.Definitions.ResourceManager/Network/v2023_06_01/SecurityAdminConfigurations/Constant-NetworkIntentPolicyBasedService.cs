// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_06_01.SecurityAdminConfigurations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NetworkIntentPolicyBasedServiceConstant
{
    [Description("All")]
    All,

    [Description("AllowRulesOnly")]
    AllowRulesOnly,

    [Description("None")]
    None,
}
