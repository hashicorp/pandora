using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Storage.v2022_09_01.TableServiceProperties;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AllowedMethodsConstant
{
    [Description("DELETE")]
    DELETE,

    [Description("GET")]
    GET,

    [Description("HEAD")]
    HEAD,

    [Description("MERGE")]
    MERGE,

    [Description("OPTIONS")]
    OPTIONS,

    [Description("PATCH")]
    PATCH,

    [Description("POST")]
    POST,

    [Description("PUT")]
    PUT,
}
