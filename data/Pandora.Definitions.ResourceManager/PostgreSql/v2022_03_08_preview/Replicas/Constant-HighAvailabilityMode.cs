using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSql.v2022_03_08_preview.Replicas;

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
