using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ContainerApps;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IngressTransportMethodConstant
{
    [Description("auto")]
    Auto,

    [Description("http")]
    Http,

    [Description("http2")]
    HttpTwo,
}
