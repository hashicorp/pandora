using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_11_01.WebApplicationFirewallPolicies;

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

    [Description("Uppercase")]
    Uppercase,

    [Description("UrlDecode")]
    UrlDecode,

    [Description("UrlEncode")]
    UrlEncode,
}
