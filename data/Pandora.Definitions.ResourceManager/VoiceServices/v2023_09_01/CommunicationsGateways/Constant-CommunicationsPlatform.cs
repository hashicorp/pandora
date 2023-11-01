using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.VoiceServices.v2023_09_01.CommunicationsGateways;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CommunicationsPlatformConstant
{
    [Description("OperatorConnect")]
    OperatorConnect,

    [Description("TeamsDirectRouting")]
    TeamsDirectRouting,

    [Description("TeamsPhoneMobile")]
    TeamsPhoneMobile,
}
