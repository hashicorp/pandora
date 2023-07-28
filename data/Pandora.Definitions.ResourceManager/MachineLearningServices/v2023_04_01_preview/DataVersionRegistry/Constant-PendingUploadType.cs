using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.DataVersionRegistry;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PendingUploadTypeConstant
{
    [Description("None")]
    None,

    [Description("TemporaryBlobReference")]
    TemporaryBlobReference,
}
