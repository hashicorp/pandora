using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_09_01.FirewallPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FirewallPolicyIntrusionDetectionStateTypeConstant
{
    [Description("Alert")]
    Alert,

    [Description("Deny")]
    Deny,

    [Description("Off")]
    Off,
}
