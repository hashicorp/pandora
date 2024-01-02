using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_08_01.BackupPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IaasVMSnapshotConsistencyTypeConstant
{
    [Description("OnlyCrashConsistent")]
    OnlyCrashConsistent,
}
