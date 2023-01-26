using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.PrivateLinkService;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NetworkInterfaceAuxiliaryModeConstant
{
    [Description("Floating")]
    Floating,

    [Description("MaxConnections")]
    MaxConnections,

    [Description("None")]
    None,
}
