using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.Api;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProtocolConstant
{
    [Description("http")]
    HTTP,

    [Description("https")]
    HTTPS,

    [Description("ws")]
    Ws,

    [Description("wss")]
    Wss,
}
