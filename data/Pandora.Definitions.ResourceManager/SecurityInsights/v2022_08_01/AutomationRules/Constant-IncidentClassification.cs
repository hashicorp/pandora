using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_08_01.AutomationRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IncidentClassificationConstant
{
    [Description("BenignPositive")]
    BenignPositive,

    [Description("FalsePositive")]
    FalsePositive,

    [Description("TruePositive")]
    TruePositive,

    [Description("Undetermined")]
    Undetermined,
}
