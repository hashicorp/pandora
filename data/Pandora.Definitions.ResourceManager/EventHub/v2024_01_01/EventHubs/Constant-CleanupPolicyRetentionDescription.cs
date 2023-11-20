using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventHub.v2024_01_01.EventHubs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CleanupPolicyRetentionDescriptionConstant
{
    [Description("Compact")]
    Compact,

    [Description("Delete")]
    Delete,
}
