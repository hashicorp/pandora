using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2023_04_01.ReplicationProtectedItems;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MultiVMGroupCreateOptionConstant
{
    [Description("AutoCreated")]
    AutoCreated,

    [Description("UserSpecified")]
    UserSpecified,
}
