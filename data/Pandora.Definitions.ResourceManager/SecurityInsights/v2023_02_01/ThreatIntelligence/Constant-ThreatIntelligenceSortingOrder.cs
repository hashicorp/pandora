using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2023_02_01.ThreatIntelligence;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ThreatIntelligenceSortingOrderConstant
{
    [Description("ascending")]
    Ascending,

    [Description("descending")]
    Descending,

    [Description("unsorted")]
    Unsorted,
}
