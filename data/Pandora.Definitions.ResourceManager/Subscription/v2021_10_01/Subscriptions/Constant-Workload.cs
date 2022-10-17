using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Subscription.v2021_10_01.Subscriptions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WorkloadConstant
{
    [Description("DevTest")]
    DevTest,

    [Description("Production")]
    Production,
}
