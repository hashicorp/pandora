using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_02_01.WebApplicationFirewallPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OwaspCrsExclusionEntrySelectorMatchOperatorConstant
{
    [Description("Contains")]
    Contains,

    [Description("EndsWith")]
    EndsWith,

    [Description("Equals")]
    Equals,

    [Description("EqualsAny")]
    EqualsAny,

    [Description("StartsWith")]
    StartsWith,
}
