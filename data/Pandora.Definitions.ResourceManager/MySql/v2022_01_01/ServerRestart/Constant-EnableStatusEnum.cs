using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MySql.v2022_01_01.ServerRestart;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EnableStatusEnumConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
