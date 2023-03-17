using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2023_02_01.ReplicationRecoveryPlans;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AlternateLocationRecoveryOptionConstant
{
    [Description("CreateVmIfNotFound")]
    CreateVMIfNotFound,

    [Description("NoAction")]
    NoAction,
}
