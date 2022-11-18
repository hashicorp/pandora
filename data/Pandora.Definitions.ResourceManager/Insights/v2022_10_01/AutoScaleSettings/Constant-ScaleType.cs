using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Insights.v2022_10_01.AutoScaleSettings;

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
