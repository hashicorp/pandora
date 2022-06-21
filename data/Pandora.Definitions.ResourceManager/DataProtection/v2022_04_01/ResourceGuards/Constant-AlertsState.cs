using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataProtection.v2022_04_01.ResourceGuards;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AlertsStateConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
