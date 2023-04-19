using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01.Schedule;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ValidationMetricTypeConstant
{
    [Description("Coco")]
    Coco,

    [Description("CocoVoc")]
    CocoVoc,

    [Description("None")]
    None,

    [Description("Voc")]
    Voc,
}
