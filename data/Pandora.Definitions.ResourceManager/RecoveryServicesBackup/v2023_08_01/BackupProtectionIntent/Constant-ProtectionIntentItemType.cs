using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_08_01.BackupProtectionIntent;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProtectionIntentItemTypeConstant
{
    [Description("AzureResourceItem")]
    AzureResourceItem,

    [Description("AzureWorkloadAutoProtectionIntent")]
    AzureWorkloadAutoProtectionIntent,

    [Description("AzureWorkloadContainerAutoProtectionIntent")]
    AzureWorkloadContainerAutoProtectionIntent,

    [Description("AzureWorkloadSQLAutoProtectionIntent")]
    AzureWorkloadSQLAutoProtectionIntent,

    [Description("Invalid")]
    Invalid,

    [Description("RecoveryServiceVaultItem")]
    RecoveryServiceVaultItem,
}
