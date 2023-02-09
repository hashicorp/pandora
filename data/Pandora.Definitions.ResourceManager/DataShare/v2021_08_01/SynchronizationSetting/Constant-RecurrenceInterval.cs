using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataShare.v2021_08_01.SynchronizationSetting;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RecurrenceIntervalConstant
{
    [Description("Day")]
    Day,

    [Description("Hour")]
    Hour,
}
