using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.ProductsByTag;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ApiTypeConstant
{
    [Description("graphql")]
    Graphql,

    [Description("http")]
    HTTP,

    [Description("odata")]
    Odata,

    [Description("soap")]
    Soap,

    [Description("websocket")]
    Websocket,
}
