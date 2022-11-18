using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2022_10_01.BenefitUtilizationSummaries;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum GrainParameterConstant
{
    [Description("Daily")]
    Daily,

    [Description("Hourly")]
    Hourly,

    [Description("Monthly")]
    Monthly,
}
