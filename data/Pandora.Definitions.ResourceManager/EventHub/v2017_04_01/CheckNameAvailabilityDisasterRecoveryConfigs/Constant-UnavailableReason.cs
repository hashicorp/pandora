using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.CheckNameAvailabilityDisasterRecoveryConfigs;

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
