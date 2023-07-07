using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSql.v2023_03_01_preview.LocationBasedCapabilities;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum HaModeConstant
{
    [Description("SameZone")]
    SameZone,

    [Description("ZoneRedundant")]
    ZoneRedundant,
}
