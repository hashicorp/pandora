using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Subscription.v2021_10_01.Subscriptions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProvisioningConstant
{
    [Description("Accepted")]
    Accepted,

    [Description("Pending")]
    Pending,

    [Description("Succeeded")]
    Succeeded,
}
