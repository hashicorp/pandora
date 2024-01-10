using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerService.v2023_10_01.ManagedClusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OutboundTypeConstant
{
    [Description("loadBalancer")]
    LoadBalancer,

    [Description("managedNATGateway")]
    ManagedNATGateway,

    [Description("userAssignedNATGateway")]
    UserAssignedNATGateway,

    [Description("userDefinedRouting")]
    UserDefinedRouting,
}
