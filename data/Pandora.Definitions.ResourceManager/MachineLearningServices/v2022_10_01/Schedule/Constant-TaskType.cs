using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.Schedule;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TaskTypeConstant
{
    [Description("Classification")]
    Classification,

    [Description("Forecasting")]
    Forecasting,

    [Description("ImageClassification")]
    ImageClassification,

    [Description("ImageClassificationMultilabel")]
    ImageClassificationMultilabel,

    [Description("ImageInstanceSegmentation")]
    ImageInstanceSegmentation,

    [Description("ImageObjectDetection")]
    ImageObjectDetection,

    [Description("Regression")]
    Regression,

    [Description("TextClassification")]
    TextClassification,

    [Description("TextClassificationMultilabel")]
    TextClassificationMultilabel,

    [Description("TextNER")]
    TextNER,
}
