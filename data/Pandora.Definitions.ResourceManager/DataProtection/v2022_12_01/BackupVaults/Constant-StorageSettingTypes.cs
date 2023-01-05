using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataProtection.v2022_12_01.BackupVaults;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StorageSettingTypesConstant
{
    [Description("GeoRedundant")]
    GeoRedundant,

    [Description("LocallyRedundant")]
    LocallyRedundant,

    [Description("ZoneRedundant")]
    ZoneRedundant,
}
