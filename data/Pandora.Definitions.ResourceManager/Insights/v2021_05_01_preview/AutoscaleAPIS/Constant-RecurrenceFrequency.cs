using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Insights.v2021_05_01_preview.AutoscaleAPIS;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RecurrenceFrequencyConstant
{
    [Description("Day")]
    Day,

    [Description("Hour")]
    Hour,

    [Description("Minute")]
    Minute,

    [Description("Month")]
    Month,

    [Description("None")]
    None,

    [Description("Second")]
    Second,

    [Description("Week")]
    Week,

    [Description("Year")]
    Year,
}
