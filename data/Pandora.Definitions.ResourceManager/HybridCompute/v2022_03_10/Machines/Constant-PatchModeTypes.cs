using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.HybridCompute.v2022_03_10.Machines;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PatchModeTypesConstant
{
    [Description("AutomaticByOS")]
    AutomaticByOS,

    [Description("AutomaticByPlatform")]
    AutomaticByPlatform,

    [Description("ImageDefault")]
    ImageDefault,

    [Description("Manual")]
    Manual,
}
