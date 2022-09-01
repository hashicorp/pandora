using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.TrafficManager.v2018_08_01.Endpoints;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EndpointMonitorStatusConstant
{
    [Description("CheckingEndpoint")]
    CheckingEndpoint,

    [Description("Degraded")]
    Degraded,

    [Description("Disabled")]
    Disabled,

    [Description("Inactive")]
    Inactive,

    [Description("Online")]
    Online,

    [Description("Stopped")]
    Stopped,
}
