using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.WebApplicationFirewallPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WebApplicationFirewallOperatorConstant
{
    [Description("Any")]
    Any,

    [Description("BeginsWith")]
    BeginsWith,

    [Description("Contains")]
    Contains,

    [Description("EndsWith")]
    EndsWith,

    [Description("Equal")]
    Equal,

    [Description("GeoMatch")]
    GeoMatch,

    [Description("GreaterThan")]
    GreaterThan,

    [Description("GreaterThanOrEqual")]
    GreaterThanOrEqual,

    [Description("IPMatch")]
    IPMatch,

    [Description("LessThan")]
    LessThan,

    [Description("LessThanOrEqual")]
    LessThanOrEqual,

    [Description("Regex")]
    Regex,
}
