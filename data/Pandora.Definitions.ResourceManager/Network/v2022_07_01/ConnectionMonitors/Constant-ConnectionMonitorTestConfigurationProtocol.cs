using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.ConnectionMonitors;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ConnectionMonitorTestConfigurationProtocolConstant
{
    [Description("Http")]
    HTTP,

    [Description("Icmp")]
    Icmp,

    [Description("Tcp")]
    Tcp,
}
