using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.LabServices.v2021_10_01_preview.Schedule
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum RecurrenceFrequencyConstant
    {
        [Description("Daily")]
        Daily,

        [Description("Weekly")]
        Weekly,
    }
}
