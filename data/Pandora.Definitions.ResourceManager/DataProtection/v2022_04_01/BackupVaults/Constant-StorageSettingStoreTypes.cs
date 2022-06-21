using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataProtection.v2022_04_01.BackupVaults;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StorageSettingStoreTypesConstant
{
    [Description("ArchiveStore")]
    ArchiveStore,

    [Description("SnapshotStore")]
    SnapshotStore,

    [Description("VaultStore")]
    VaultStore,
}
