using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.QueueServiceProperties;

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

    [Description("POST")]
    POST,

    [Description("PUT")]
    PUT,
}
