using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AppPlatform.v2023_07_01_preview.AppPlatform;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SupportedRuntimePlatformConstant
{
    [Description("Java")]
    Java,

    [Description(".NET Core")]
    PointNETCore,
}
