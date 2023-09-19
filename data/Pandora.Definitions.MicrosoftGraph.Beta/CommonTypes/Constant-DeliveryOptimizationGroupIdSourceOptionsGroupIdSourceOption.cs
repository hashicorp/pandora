// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DeliveryOptimizationGroupIdSourceOptionsGroupIdSourceOptionConstant
{
    [Description("NotConfigured")]
    @notConfigured,

    [Description("AdSite")]
    @adSite,

    [Description("AuthenticatedDomainSid")]
    @authenticatedDomainSid,

    [Description("DhcpUserOption")]
    @dhcpUserOption,

    [Description("DnsSuffix")]
    @dnsSuffix,
}
