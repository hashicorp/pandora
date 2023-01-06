using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2021_12_01.BackupResourceEncryptionConfigs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LastUpdateStatusConstant
{
    [Description("Failed")]
    Failed,

    [Description("FirstInitialization")]
    FirstInitialization,

    [Description("Initialized")]
    Initialized,

    [Description("Invalid")]
    Invalid,

    [Description("NotEnabled")]
    NotEnabled,

    [Description("PartiallyFailed")]
    PartiallyFailed,

    [Description("PartiallySucceeded")]
    PartiallySucceeded,

    [Description("Succeeded")]
    Succeeded,
}
