using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_05_01.Job;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OutputDeliveryModeConstant
{
    [Description("ReadWriteMount")]
    ReadWriteMount,

    [Description("Upload")]
    Upload,
}
