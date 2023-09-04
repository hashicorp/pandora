using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2023_06_01_preview.ImportPipelines;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PipelineOptionsConstant
{
    [Description("ContinueOnErrors")]
    ContinueOnErrors,

    [Description("DeleteSourceBlobOnSuccess")]
    DeleteSourceBlobOnSuccess,

    [Description("OverwriteBlobs")]
    OverwriteBlobs,

    [Description("OverwriteTags")]
    OverwriteTags,
}
