using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Advisor.v2022_10_01.GetRecommendations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CategoryConstant
{
    [Description("Cost")]
    Cost,

    [Description("HighAvailability")]
    HighAvailability,

    [Description("OperationalExcellence")]
    OperationalExcellence,

    [Description("Performance")]
    Performance,

    [Description("Security")]
    Security,
}
