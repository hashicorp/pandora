using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataProtection.v2022_05_01.BackupInstances;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SourceDataStoreTypeConstant
{
    [Description("ArchiveStore")]
    ArchiveStore,

    [Description("SnapshotStore")]
    SnapshotStore,

    [Description("VaultStore")]
    VaultStore,
}
