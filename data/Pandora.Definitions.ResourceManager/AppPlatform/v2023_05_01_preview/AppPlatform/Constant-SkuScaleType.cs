using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AppPlatform.v2023_05_01_preview.AppPlatform;

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
