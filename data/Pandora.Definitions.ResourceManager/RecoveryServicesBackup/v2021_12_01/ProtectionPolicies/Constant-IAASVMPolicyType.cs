using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2021_12_01.ProtectionPolicies;

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
