using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_10_01.BackupPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IAASVMPolicyTypeConstant
{
    [Description("Invalid")]
    Invalid,

    [Description("V1")]
    VOne,

    [Description("V2")]
    VTwo,
}
