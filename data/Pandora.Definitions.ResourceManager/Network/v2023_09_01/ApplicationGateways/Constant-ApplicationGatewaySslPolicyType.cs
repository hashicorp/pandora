using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.ApplicationGateways;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ApplicationGatewaySslPolicyTypeConstant
{
    [Description("Custom")]
    Custom,

    [Description("CustomV2")]
    CustomVTwo,

    [Description("Predefined")]
    Predefined,
}
