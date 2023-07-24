using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.WebApps;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SiteLoadBalancingConstant
{
    [Description("LeastRequests")]
    LeastRequests,

    [Description("LeastResponseTime")]
    LeastResponseTime,

    [Description("PerSiteRoundRobin")]
    PerSiteRoundRobin,

    [Description("RequestHash")]
    RequestHash,

    [Description("WeightedRoundRobin")]
    WeightedRoundRobin,

    [Description("WeightedTotalTraffic")]
    WeightedTotalTraffic,
}
