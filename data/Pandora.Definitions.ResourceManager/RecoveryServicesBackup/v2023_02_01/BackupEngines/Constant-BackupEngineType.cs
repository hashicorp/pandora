using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_02_01.BackupEngines;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BackupEngineTypeConstant
{
    [Description("AzureBackupServerEngine")]
    AzureBackupServerEngine,

    [Description("DpmBackupEngine")]
    DpmBackupEngine,

    [Description("Invalid")]
    Invalid,
}
