using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2021_12_01.ProtectionIntent;

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
