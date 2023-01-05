using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MySql.v2021_12_01_preview.Configurations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IsDynamicConfigConstant
{
    [Description("False")]
    False,

    [Description("True")]
    True,
}
