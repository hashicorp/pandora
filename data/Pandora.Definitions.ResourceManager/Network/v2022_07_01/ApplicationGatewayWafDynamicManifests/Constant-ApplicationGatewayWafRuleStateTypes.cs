using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.ApplicationGatewayWafDynamicManifests;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ApplicationGatewayWafRuleStateTypesConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
