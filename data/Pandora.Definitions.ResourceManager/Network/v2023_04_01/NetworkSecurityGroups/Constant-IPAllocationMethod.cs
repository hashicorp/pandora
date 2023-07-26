using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_04_01.NetworkSecurityGroups;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IPAllocationMethodConstant
{
    [Description("Dynamic")]
    Dynamic,

    [Description("Static")]
    Static,
}
