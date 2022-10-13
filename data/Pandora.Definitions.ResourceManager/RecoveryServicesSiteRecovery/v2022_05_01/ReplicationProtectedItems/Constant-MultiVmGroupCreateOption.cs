using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_05_01.ReplicationProtectedItems;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MultiVmGroupCreateOptionConstant
{
    [Description("AutoCreated")]
    AutoCreated,

    [Description("UserSpecified")]
    UserSpecified,
}
