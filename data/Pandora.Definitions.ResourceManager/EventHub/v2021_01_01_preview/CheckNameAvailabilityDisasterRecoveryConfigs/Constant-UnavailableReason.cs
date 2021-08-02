using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_01_01_preview.CheckNameAvailabilityDisasterRecoveryConfigs
{
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
}
