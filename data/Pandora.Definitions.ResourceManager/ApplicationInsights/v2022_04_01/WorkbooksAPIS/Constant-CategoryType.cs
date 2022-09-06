using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2022_04_01.WorkbooksAPIS;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CategoryTypeConstant
{
    [Description("performance")]
    Performance,

    [Description("retention")]
    Retention,

    [Description("TSG")]
    TSG,

    [Description("workbook")]
    Workbook,
}
