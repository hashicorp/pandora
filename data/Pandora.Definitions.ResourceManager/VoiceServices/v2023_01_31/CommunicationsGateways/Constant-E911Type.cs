using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.VoiceServices.v2023_01_31.CommunicationsGateways;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum E911TypeConstant
{
    [Description("DirectToEsrp")]
    DirectToEsrp,

    [Description("Standard")]
    Standard,
}
