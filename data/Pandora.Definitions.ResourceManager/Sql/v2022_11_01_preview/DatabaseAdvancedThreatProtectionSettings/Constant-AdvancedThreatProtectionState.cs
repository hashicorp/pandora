using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.DatabaseAdvancedThreatProtectionSettings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AdvancedThreatProtectionStateConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,

    [Description("New")]
    New,
}
