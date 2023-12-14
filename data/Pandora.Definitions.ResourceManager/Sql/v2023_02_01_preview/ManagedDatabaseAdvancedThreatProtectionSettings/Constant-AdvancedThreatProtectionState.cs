using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.ManagedDatabaseAdvancedThreatProtectionSettings;

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
