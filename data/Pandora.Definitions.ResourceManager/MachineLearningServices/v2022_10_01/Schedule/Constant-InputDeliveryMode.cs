using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.Schedule;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum InputDeliveryModeConstant
{
    [Description("Direct")]
    Direct,

    [Description("Download")]
    Download,

    [Description("EvalDownload")]
    EvalDownload,

    [Description("EvalMount")]
    EvalMount,

    [Description("ReadOnlyMount")]
    ReadOnlyMount,

    [Description("ReadWriteMount")]
    ReadWriteMount,
}
