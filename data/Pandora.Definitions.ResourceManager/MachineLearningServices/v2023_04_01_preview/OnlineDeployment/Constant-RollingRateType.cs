using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.OnlineDeployment;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RollingRateTypeConstant
{
    [Description("Day")]
    Day,

    [Description("Hour")]
    Hour,

    [Description("Minute")]
    Minute,

    [Description("Month")]
    Month,

    [Description("Year")]
    Year,
}
