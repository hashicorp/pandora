using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AppPlatform.v2023_12_01.AppPlatform;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SkuScaleTypeConstant
{
    [Description("Automatic")]
    Automatic,

    [Description("Manual")]
    Manual,

    [Description("None")]
    None,
}
