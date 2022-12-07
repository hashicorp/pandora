using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_10_01.BackupResourceStorageConfigsNonCRR;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StorageTypeConstant
{
    [Description("GeoRedundant")]
    GeoRedundant,

    [Description("Invalid")]
    Invalid,

    [Description("LocallyRedundant")]
    LocallyRedundant,

    [Description("ReadAccessGeoZoneRedundant")]
    ReadAccessGeoZoneRedundant,

    [Description("ZoneRedundant")]
    ZoneRedundant,
}
