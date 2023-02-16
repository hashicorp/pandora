using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Advisor.v2022_10_01.GetRecommendations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RiskConstant
{
    [Description("Error")]
    Error,

    [Description("None")]
    None,

    [Description("Warning")]
    Warning,
}
