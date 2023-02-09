using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataShare.v2019_11_01.ConsumerInvitation;

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
