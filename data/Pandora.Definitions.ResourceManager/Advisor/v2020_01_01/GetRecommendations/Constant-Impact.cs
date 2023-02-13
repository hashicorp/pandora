using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Advisor.v2020_01_01.GetRecommendations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ImpactConstant
{
    [Description("High")]
    High,

    [Description("Low")]
    Low,

    [Description("Medium")]
    Medium,
}
