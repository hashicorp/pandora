using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.WorkflowTriggers;

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

    [Description("NotSpecified")]
    NotSpecified,

    [Description("Second")]
    Second,

    [Description("Week")]
    Week,

    [Description("Year")]
    Year,
}
