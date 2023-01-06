using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2021_12_01.ProtectedItems;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BackupManagementTypeConstant
{
    [Description("AzureBackupServer")]
    AzureBackupServer,

    [Description("AzureIaasVM")]
    AzureIaasVM,

    [Description("AzureSql")]
    AzureSql,

    [Description("AzureStorage")]
    AzureStorage,

    [Description("AzureWorkload")]
    AzureWorkload,

    [Description("DPM")]
    DPM,

    [Description("DefaultBackup")]
    DefaultBackup,

    [Description("Invalid")]
    Invalid,

    [Description("MAB")]
    MAB,
}
