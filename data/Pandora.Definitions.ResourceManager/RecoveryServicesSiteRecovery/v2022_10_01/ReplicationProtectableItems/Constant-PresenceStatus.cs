using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationProtectableItems;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PresenceStatusConstant
{
    [Description("NotPresent")]
    NotPresent,

    [Description("Present")]
    Present,

    [Description("Unknown")]
    Unknown,
}
