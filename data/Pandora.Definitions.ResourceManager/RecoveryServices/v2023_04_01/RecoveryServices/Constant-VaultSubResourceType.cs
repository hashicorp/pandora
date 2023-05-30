using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServices.v2023_04_01.RecoveryServices;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VaultSubResourceTypeConstant
{
    [Description("AzureBackup")]
    AzureBackup,

    [Description("AzureBackup_secondary")]
    AzureBackupSecondary,

    [Description("AzureSiteRecovery")]
    AzureSiteRecovery,
}
