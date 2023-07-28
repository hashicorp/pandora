using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.OperationalizationClusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VolumeDefinitionTypeConstant
{
    [Description("bind")]
    Bind,

    [Description("npipe")]
    Npipe,

    [Description("tmpfs")]
    Tmpfs,

    [Description("volume")]
    Volume,
}
