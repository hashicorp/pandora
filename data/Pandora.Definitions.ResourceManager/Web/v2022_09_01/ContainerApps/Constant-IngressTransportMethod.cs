using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.ContainerApps;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IngressTransportMethodConstant
{
    [Description("auto")]
    Auto,

    [Description("http")]
    HTTP,

    [Description("http2")]
    HTTPTwo,
}
