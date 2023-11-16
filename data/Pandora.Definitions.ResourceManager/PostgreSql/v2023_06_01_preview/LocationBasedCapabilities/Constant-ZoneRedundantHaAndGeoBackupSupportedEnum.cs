using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSql.v2023_06_01_preview.LocationBasedCapabilities;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ZoneRedundantHaAndGeoBackupSupportedEnumConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
