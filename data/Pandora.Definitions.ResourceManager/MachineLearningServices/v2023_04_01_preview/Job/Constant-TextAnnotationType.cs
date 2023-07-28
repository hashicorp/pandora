using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.Job;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TextAnnotationTypeConstant
{
    [Description("Classification")]
    Classification,

    [Description("NamedEntityRecognition")]
    NamedEntityRecognition,
}
