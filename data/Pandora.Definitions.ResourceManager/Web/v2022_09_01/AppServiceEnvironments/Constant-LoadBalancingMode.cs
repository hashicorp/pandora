using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.AppServiceEnvironments;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LoadBalancingModeConstant
{
    [Description("None")]
    None,

    [Description("Publishing")]
    Publishing,

    [Description("Web")]
    Web,

    [Description("Web, Publishing")]
    WebPublishing,
}
