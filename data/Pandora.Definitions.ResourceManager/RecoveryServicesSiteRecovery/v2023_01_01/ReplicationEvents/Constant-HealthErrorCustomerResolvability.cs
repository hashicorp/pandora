using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2023_01_01.ReplicationEvents;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum HealthErrorCustomerResolvabilityConstant
{
    [Description("Allowed")]
    Allowed,

    [Description("NotAllowed")]
    NotAllowed,
}
