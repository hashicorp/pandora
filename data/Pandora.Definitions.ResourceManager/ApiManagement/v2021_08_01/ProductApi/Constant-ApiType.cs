using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.ProductApi;

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
