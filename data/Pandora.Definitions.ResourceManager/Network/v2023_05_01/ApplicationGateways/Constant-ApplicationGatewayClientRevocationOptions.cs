using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_05_01.ApplicationGateways;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ApplicationGatewayClientRevocationOptionsConstant
{
    [Description("None")]
    None,

    [Description("OCSP")]
    OCSP,
}
