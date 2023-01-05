using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MySql.v2021_12_01_preview.ServerRestart;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EnableStatusEnumConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
