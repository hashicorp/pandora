using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_04_01.WebApplicationFirewallPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ManagedRuleExclusionMatchVariableConstant
{
    [Description("QueryStringArgNames")]
    QueryStringArgNames,

    [Description("RequestBodyPostArgNames")]
    RequestBodyPostArgNames,

    [Description("RequestCookieNames")]
    RequestCookieNames,

    [Description("RequestHeaderNames")]
    RequestHeaderNames,
}
