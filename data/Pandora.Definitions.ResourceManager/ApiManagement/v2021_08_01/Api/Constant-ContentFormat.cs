using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.Api;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ContentFormatConstant
{
    [Description("graphql-link")]
    GraphqlNegativelink,

    [Description("openapi")]
    Openapi,

    [Description("openapi-link")]
    OpenapiNegativelink,

    [Description("openapi+json")]
    OpenapiPositivejson,

    [Description("openapi+json-link")]
    OpenapiPositivejsonNegativelink,

    [Description("swagger-json")]
    SwaggerNegativejson,

    [Description("swagger-link-json")]
    SwaggerNegativelinkNegativejson,

    [Description("wadl-link-json")]
    WadlNegativelinkNegativejson,

    [Description("wadl-xml")]
    WadlNegativexml,

    [Description("wsdl")]
    Wsdl,

    [Description("wsdl-link")]
    WsdlNegativelink,
}
