using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.Api;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SoapApiTypeConstant
{
    [Description("graphql")]
    Graphql,

    [Description("http")]
    HTTP,

    [Description("soap")]
    Soap,

    [Description("websocket")]
    Websocket,
}
