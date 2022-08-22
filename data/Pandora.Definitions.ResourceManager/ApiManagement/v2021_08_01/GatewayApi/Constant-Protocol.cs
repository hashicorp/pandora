using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.GatewayApi;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProtocolConstant
{
    [Description("http")]
    Http,

    [Description("https")]
    Https,

    [Description("ws")]
    Ws,

    [Description("wss")]
    Wss,
}
