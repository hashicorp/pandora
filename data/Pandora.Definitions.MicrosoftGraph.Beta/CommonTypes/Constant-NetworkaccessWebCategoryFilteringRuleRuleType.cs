// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NetworkaccessWebCategoryFilteringRuleRuleTypeConstant
{
    [Description("Url")]
    @url,

    [Description("Fqdn")]
    @fqdn,

    [Description("IpAddress")]
    @ipAddress,

    [Description("IpRange")]
    @ipRange,

    [Description("IpSubnet")]
    @ipSubnet,

    [Description("WebCategory")]
    @webCategory,
}
