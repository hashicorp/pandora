using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.DscpConfigurations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IPAllocationMethodConstant
{
    [Description("Dynamic")]
    Dynamic,

    [Description("Static")]
    Static,
}
