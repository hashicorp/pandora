using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_08_01.PrivateEndpointConnection;

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
