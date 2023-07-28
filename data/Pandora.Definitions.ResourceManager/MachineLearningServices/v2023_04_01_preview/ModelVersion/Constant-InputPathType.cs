using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.ModelVersion;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum InputPathTypeConstant
{
    [Description("PathId")]
    PathId,

    [Description("PathVersion")]
    PathVersion,

    [Description("Url")]
    Url,
}
