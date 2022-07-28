using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.ApplicationGateways;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ApplicationGatewayFirewallModeConstant
{
    [Description("Detection")]
    Detection,

    [Description("Prevention")]
    Prevention,
}
