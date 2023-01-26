using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.ApplicationGatewayWafDynamicManifests;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ApplicationGatewayRuleSetStatusOptionsConstant
{
    [Description("Deprecated")]
    Deprecated,

    [Description("GA")]
    GA,

    [Description("Preview")]
    Preview,

    [Description("Supported")]
    Supported,
}
