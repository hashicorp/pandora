// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.ApplicationGatewayWafDynamicManifests;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ApplicationGatewayWafRuleActionTypesConstant
{
    [Description("Allow")]
    Allow,

    [Description("AnomalyScoring")]
    AnomalyScoring,

    [Description("Block")]
    Block,

    [Description("Log")]
    Log,

    [Description("None")]
    None,
}
