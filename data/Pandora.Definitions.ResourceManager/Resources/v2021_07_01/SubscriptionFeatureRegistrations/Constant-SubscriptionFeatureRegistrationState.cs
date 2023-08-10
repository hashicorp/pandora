using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Resources.v2021_07_01.SubscriptionFeatureRegistrations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SubscriptionFeatureRegistrationStateConstant
{
    [Description("NotRegistered")]
    NotRegistered,

    [Description("NotSpecified")]
    NotSpecified,

    [Description("Pending")]
    Pending,

    [Description("Registered")]
    Registered,

    [Description("Registering")]
    Registering,

    [Description("Unregistered")]
    Unregistered,

    [Description("Unregistering")]
    Unregistering,
}
