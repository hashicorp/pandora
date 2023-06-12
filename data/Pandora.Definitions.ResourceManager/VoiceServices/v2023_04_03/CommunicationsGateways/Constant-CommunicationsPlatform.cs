using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.VoiceServices.v2023_04_03.CommunicationsGateways;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CommunicationsPlatformConstant
{
    [Description("OperatorConnect")]
    OperatorConnect,

    [Description("TeamsPhoneMobile")]
    TeamsPhoneMobile,
}
