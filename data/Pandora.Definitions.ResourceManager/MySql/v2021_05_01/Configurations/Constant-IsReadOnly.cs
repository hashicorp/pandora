using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MySql.v2021_05_01.Configurations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IsReadOnlyConstant
{
    [Description("False")]
    False,

    [Description("True")]
    True,
}
