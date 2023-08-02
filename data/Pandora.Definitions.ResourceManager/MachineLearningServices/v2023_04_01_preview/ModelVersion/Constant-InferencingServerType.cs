using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.ModelVersion;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum InferencingServerTypeConstant
{
    [Description("AzureMLBatch")]
    AzureMLBatch,

    [Description("AzureMLOnline")]
    AzureMLOnline,

    [Description("Custom")]
    Custom,

    [Description("Triton")]
    Triton,
}
