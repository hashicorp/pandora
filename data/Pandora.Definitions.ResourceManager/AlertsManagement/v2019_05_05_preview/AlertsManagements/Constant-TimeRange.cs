using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AlertsManagement.v2019_05_05_preview.AlertsManagements;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TimeRangeConstant
{
    [Description("1d")]
    Oned,

    [Description("1h")]
    Oneh,

    [Description("7d")]
    Sevend,

    [Description("30d")]
    ThreeZerod,
}
