using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2023_06_01_preview.PipelineRuns;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PipelineRunTargetTypeConstant
{
    [Description("AzureStorageBlob")]
    AzureStorageBlob,
}
