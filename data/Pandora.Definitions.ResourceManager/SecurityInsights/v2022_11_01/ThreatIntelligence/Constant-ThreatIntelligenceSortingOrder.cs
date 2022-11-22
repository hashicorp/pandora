using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_11_01.ThreatIntelligence;

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
