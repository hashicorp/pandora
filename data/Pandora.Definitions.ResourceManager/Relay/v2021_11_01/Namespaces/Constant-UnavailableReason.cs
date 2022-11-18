using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Relay.v2021_11_01.Namespaces;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum UnavailableReasonConstant
{
    [Description("InvalidName")]
    InvalidName,

    [Description("NameInLockdown")]
    NameInLockdown,

    [Description("NameInUse")]
    NameInUse,

    [Description("None")]
    None,

    [Description("SubscriptionIsDisabled")]
    SubscriptionIsDisabled,

    [Description("TooManyNamespaceInCurrentSubscription")]
    TooManyNamespaceInCurrentSubscription,
}
