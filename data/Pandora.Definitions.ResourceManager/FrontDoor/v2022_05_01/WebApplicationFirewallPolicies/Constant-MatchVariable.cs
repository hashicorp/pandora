using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.FrontDoor.v2022_05_01.WebApplicationFirewallPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MatchVariableConstant
{
    [Description("Cookies")]
    Cookies,

    [Description("PostArgs")]
    PostArgs,

    [Description("QueryString")]
    QueryString,

    [Description("RemoteAddr")]
    RemoteAddr,

    [Description("RequestBody")]
    RequestBody,

    [Description("RequestHeader")]
    RequestHeader,

    [Description("RequestMethod")]
    RequestMethod,

    [Description("RequestUri")]
    RequestUri,

    [Description("SocketAddr")]
    SocketAddr,
}
