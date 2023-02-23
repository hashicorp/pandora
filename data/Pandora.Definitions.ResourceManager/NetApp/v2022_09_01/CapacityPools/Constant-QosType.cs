using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NetApp.v2022_09_01.CapacityPools;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum QosTypeConstant
{
    [Description("Auto")]
    Auto,

    [Description("Manual")]
    Manual,
}
