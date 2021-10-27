using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_04_01.WebApplicationFirewallPolicies
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum TransformTypeConstant
    {
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
}
