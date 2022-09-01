using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.AuthorizationServer;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AuthorizationMethodConstant
{
    [Description("DELETE")]
    DELETE,

    [Description("GET")]
    GET,

    [Description("HEAD")]
    HEAD,

    [Description("OPTIONS")]
    OPTIONS,

    [Description("PATCH")]
    PATCH,

    [Description("POST")]
    POST,

    [Description("PUT")]
    PUT,

    [Description("TRACE")]
    TRACE,
}
