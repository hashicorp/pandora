using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataShare.v2021_08_01.ShareSubscription;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ShareSubscriptionStatusConstant
{
    [Description("Active")]
    Active,

    [Description("Revoked")]
    Revoked,

    [Description("Revoking")]
    Revoking,

    [Description("SourceDeleted")]
    SourceDeleted,
}
