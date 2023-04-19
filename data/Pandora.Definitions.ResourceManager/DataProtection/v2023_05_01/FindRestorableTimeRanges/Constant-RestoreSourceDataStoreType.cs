using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataProtection.v2023_05_01.FindRestorableTimeRanges;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RestoreSourceDataStoreTypeConstant
{
    [Description("ArchiveStore")]
    ArchiveStore,

    [Description("OperationalStore")]
    OperationalStore,

    [Description("VaultStore")]
    VaultStore,
}
