using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.LabServices.v2021_10_01_preview.User;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum InvitationStateConstant
{
    [Description("Failed")]
    Failed,

    [Description("NotSent")]
    NotSent,

    [Description("Sending")]
    Sending,

    [Description("Sent")]
    Sent,
}
