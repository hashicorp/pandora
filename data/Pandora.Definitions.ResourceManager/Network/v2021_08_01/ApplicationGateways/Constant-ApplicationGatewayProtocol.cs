using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.ApplicationGateways;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ApplicationGatewayProtocolConstant
{
    [Description("Http")]
    Http,

    [Description("Https")]
    Https,

    [Description("Tcp")]
    Tcp,

    [Description("Tls")]
    Tls,
}
