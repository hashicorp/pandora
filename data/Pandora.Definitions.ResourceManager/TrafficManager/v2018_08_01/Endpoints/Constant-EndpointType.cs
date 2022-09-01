using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.TrafficManager.v2018_08_01.Endpoints;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EndpointTypeConstant
{
    [Description("AzureEndpoints")]
    AzureEndpoints,

    [Description("ExternalEndpoints")]
    ExternalEndpoints,

    [Description("NestedEndpoints")]
    NestedEndpoints,
}
