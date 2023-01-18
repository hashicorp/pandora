using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationServiceEnvironmentNetworkHealth;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IntegrationServiceEnvironmentNetworkDependencyHealthStateConstant
{
    [Description("Healthy")]
    Healthy,

    [Description("NotSpecified")]
    NotSpecified,

    [Description("Unhealthy")]
    Unhealthy,

    [Description("Unknown")]
    Unknown,
}
