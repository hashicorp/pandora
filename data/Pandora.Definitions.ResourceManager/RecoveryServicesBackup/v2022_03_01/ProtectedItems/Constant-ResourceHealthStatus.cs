using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_03_01.ProtectedItems;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ResourceHealthStatusConstant
{
    [Description("Healthy")]
    Healthy,

    [Description("Invalid")]
    Invalid,

    [Description("PersistentDegraded")]
    PersistentDegraded,

    [Description("PersistentUnhealthy")]
    PersistentUnhealthy,

    [Description("TransientDegraded")]
    TransientDegraded,

    [Description("TransientUnhealthy")]
    TransientUnhealthy,
}
