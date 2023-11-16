using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSql.v2023_06_01_preview.Servers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum HighAvailabilityModeConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("SameZone")]
    SameZone,

    [Description("ZoneRedundant")]
    ZoneRedundant,
}
