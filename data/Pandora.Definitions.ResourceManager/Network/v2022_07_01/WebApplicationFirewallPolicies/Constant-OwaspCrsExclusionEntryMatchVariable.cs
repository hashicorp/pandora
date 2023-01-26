using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.WebApplicationFirewallPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OwaspCrsExclusionEntryMatchVariableConstant
{
    [Description("RequestArgKeys")]
    RequestArgKeys,

    [Description("RequestArgNames")]
    RequestArgNames,

    [Description("RequestArgValues")]
    RequestArgValues,

    [Description("RequestCookieKeys")]
    RequestCookieKeys,

    [Description("RequestCookieNames")]
    RequestCookieNames,

    [Description("RequestCookieValues")]
    RequestCookieValues,

    [Description("RequestHeaderKeys")]
    RequestHeaderKeys,

    [Description("RequestHeaderNames")]
    RequestHeaderNames,

    [Description("RequestHeaderValues")]
    RequestHeaderValues,
}
