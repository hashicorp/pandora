using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AppPlatform.v2022_09_01_preview.AppPlatform;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SupportedRuntimeValueConstant
{
    [Description("Java_8")]
    JavaEight,

    [Description("Java_11")]
    JavaOneOne,

    [Description("Java_17")]
    JavaOneSeven,

    [Description("NetCore_31")]
    NetCoreThreeOne,
}
