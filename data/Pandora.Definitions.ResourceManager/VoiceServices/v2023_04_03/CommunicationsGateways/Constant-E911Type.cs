using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.VoiceServices.v2023_04_03.CommunicationsGateways;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum E911TypeConstant
{
    [Description("DirectToEsrp")]
    DirectToEsrp,

    [Description("Standard")]
    Standard,
}
