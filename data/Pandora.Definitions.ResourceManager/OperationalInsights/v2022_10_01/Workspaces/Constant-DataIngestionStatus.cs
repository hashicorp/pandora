using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2022_10_01.Workspaces;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DataIngestionStatusConstant
{
    [Description("ApproachingQuota")]
    ApproachingQuota,

    [Description("ForceOff")]
    ForceOff,

    [Description("ForceOn")]
    ForceOn,

    [Description("OverQuota")]
    OverQuota,

    [Description("RespectQuota")]
    RespectQuota,

    [Description("SubscriptionSuspended")]
    SubscriptionSuspended,
}
