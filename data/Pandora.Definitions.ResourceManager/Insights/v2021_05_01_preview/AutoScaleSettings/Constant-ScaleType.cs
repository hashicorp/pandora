using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Insights.v2021_05_01_preview.AutoScaleSettings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ScaleTypeConstant
{
    [Description("ChangeCount")]
    ChangeCount,

    [Description("ExactCount")]
    ExactCount,

    [Description("PercentChangeCount")]
    PercentChangeCount,

    [Description("ServiceAllowedNextValue")]
    ServiceAllowedNextValue,
}
