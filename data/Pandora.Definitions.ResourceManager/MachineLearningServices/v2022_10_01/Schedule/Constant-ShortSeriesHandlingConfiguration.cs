using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.Schedule;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ShortSeriesHandlingConfigurationConstant
{
    [Description("Auto")]
    Auto,

    [Description("Drop")]
    Drop,

    [Description("None")]
    None,

    [Description("Pad")]
    Pad,
}
