using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.WebApplicationFirewallPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WebApplicationFirewallTransformConstant
{
    [Description("HtmlEntityDecode")]
    HtmlEntityDecode,

    [Description("Lowercase")]
    Lowercase,

    [Description("RemoveNulls")]
    RemoveNulls,

    [Description("Trim")]
    Trim,

    [Description("UrlDecode")]
    UrlDecode,

    [Description("UrlEncode")]
    UrlEncode,
}
