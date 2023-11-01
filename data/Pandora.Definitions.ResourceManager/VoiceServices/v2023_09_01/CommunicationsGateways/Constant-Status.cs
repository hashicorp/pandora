using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.VoiceServices.v2023_09_01.CommunicationsGateways;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StatusConstant
{
    [Description("ChangePending")]
    ChangePending,

    [Description("Complete")]
    Complete,
}
