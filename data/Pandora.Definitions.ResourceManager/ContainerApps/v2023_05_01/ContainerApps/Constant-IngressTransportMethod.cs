using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2023_05_01.ContainerApps;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IngressTransportMethodConstant
{
    [Description("auto")]
    Auto,

    [Description("http")]
    HTTP,

    [Description("http2")]
    HTTPTwo,

    [Description("tcp")]
    Tcp,
}
