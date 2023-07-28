using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.LabelingJob;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OutputDeliveryModeConstant
{
    [Description("Direct")]
    Direct,

    [Description("ReadWriteMount")]
    ReadWriteMount,

    [Description("Upload")]
    Upload,
}
