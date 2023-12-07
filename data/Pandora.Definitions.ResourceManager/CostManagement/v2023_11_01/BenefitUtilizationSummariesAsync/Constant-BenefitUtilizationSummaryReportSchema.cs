using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2023_11_01.BenefitUtilizationSummariesAsync;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BenefitUtilizationSummaryReportSchemaConstant
{
    [Description("AvgUtilizationPercentage")]
    AvgUtilizationPercentage,

    [Description("BenefitId")]
    BenefitId,

    [Description("BenefitOrderId")]
    BenefitOrderId,

    [Description("BenefitType")]
    BenefitType,

    [Description("Kind")]
    Kind,

    [Description("MaxUtilizationPercentage")]
    MaxUtilizationPercentage,

    [Description("MinUtilizationPercentage")]
    MinUtilizationPercentage,

    [Description("UsageDate")]
    UsageDate,

    [Description("UtilizedPercentage")]
    UtilizedPercentage,
}
