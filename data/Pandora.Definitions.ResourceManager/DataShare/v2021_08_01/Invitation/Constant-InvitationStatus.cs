using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataShare.v2021_08_01.Invitation;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum InvitationStatusConstant
{
    [Description("Accepted")]
    Accepted,

    [Description("Pending")]
    Pending,

    [Description("Rejected")]
    Rejected,

    [Description("Withdrawn")]
    Withdrawn,
}
