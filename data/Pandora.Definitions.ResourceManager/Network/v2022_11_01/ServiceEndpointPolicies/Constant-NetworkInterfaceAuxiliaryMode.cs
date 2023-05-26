using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_11_01.ServiceEndpointPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NetworkInterfaceAuxiliaryModeConstant
{
    [Description("AcceleratedConnections")]
    AcceleratedConnections,

    [Description("Floating")]
    Floating,

    [Description("MaxConnections")]
    MaxConnections,

    [Description("None")]
    None,
}
