using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.IPAllocations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IPAllocationTypeConstant
{
    [Description("Hypernet")]
    Hypernet,

    [Description("Undefined")]
    Undefined,
}
