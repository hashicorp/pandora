// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NetworkaccessM365ForwardingRuleProtocolConstant
{
    [Description("Ip")]
    @ip,

    [Description("Icmp")]
    @icmp,

    [Description("Igmp")]
    @igmp,

    [Description("Ggp")]
    @ggp,

    [Description("Ipv4")]
    @ipv4,

    [Description("Tcp")]
    @tcp,

    [Description("Pup")]
    @pup,

    [Description("Udp")]
    @udp,

    [Description("Idp")]
    @idp,

    [Description("Ipv6")]
    @ipv6,

    [Description("Ipv6RoutingHeader")]
    @ipv6RoutingHeader,

    [Description("Ipv6FragmentHeader")]
    @ipv6FragmentHeader,

    [Description("IpSecEncapsulatingSecurityPayload")]
    @ipSecEncapsulatingSecurityPayload,

    [Description("IpSecAuthenticationHeader")]
    @ipSecAuthenticationHeader,

    [Description("IcmpV6")]
    @icmpV6,

    [Description("Ipv6NoNextHeader")]
    @ipv6NoNextHeader,

    [Description("Ipv6DestinationOptions")]
    @ipv6DestinationOptions,

    [Description("Nd")]
    @nd,

    [Description("Ipx")]
    @ipx,

    [Description("Raw")]
    @raw,

    [Description("Spx")]
    @spx,

    [Description("SpxII")]
    @spxII,
}
