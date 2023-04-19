using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Resources.v2022_12_01.Subscriptions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SubscriptionStateConstant
{
    [Description("Deleted")]
    Deleted,

    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,

    [Description("PastDue")]
    PastDue,

    [Description("Warned")]
    Warned,
}
