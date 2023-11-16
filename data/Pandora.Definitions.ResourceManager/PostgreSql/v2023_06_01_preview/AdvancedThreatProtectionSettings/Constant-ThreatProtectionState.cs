using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSql.v2023_06_01_preview.AdvancedThreatProtectionSettings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ThreatProtectionStateConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
