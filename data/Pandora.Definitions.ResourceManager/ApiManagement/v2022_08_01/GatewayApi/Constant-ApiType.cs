using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.GatewayApi;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ApiTypeConstant
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
