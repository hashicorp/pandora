using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.NetworkInterfaces;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProbeProtocolConstant
{
    [Description("Http")]
    Http,

    [Description("Https")]
    Https,

    [Description("Tcp")]
    Tcp,
}
