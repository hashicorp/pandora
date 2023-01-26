using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.NetworkWatchers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IssueTypeConstant
{
    [Description("AgentStopped")]
    AgentStopped,

    [Description("DnsResolution")]
    DnsResolution,

    [Description("GuestFirewall")]
    GuestFirewall,

    [Description("NetworkSecurityRule")]
    NetworkSecurityRule,

    [Description("Platform")]
    Platform,

    [Description("PortThrottled")]
    PortThrottled,

    [Description("SocketBind")]
    SocketBind,

    [Description("Unknown")]
    Unknown,

    [Description("UserDefinedRoute")]
    UserDefinedRoute,
}
