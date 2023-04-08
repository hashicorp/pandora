using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2019_08_01.IoTSecurityRecommendationTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RecommendationSeverityConstant
{
    [Description("Healthy")]
    Healthy,

    [Description("High")]
    High,

    [Description("Low")]
    Low,

    [Description("Medium")]
    Medium,

    [Description("NotApplicable")]
    NotApplicable,

    [Description("OffByPolicy")]
    OffByPolicy,

    [Description("Unknown")]
    Unknown,
}
