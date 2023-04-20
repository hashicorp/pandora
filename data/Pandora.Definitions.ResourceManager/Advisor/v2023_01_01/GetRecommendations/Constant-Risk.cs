using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Advisor.v2023_01_01.GetRecommendations;

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
