using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_10_01_preview.DataConnectors;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PollingFrequencyConstant
{
    [Description("OnceADay")]
    OnceADay,

    [Description("OnceAMinute")]
    OnceAMinute,

    [Description("OnceAnHour")]
    OnceAnHour,
}
