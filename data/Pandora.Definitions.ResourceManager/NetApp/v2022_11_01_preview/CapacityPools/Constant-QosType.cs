using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NetApp.v2022_11_01_preview.CapacityPools;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum QosTypeConstant
{
    [Description("Auto")]
    Auto,

    [Description("Manual")]
    Manual,
}
