using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.Schedule;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BlockedTransformersConstant
{
    [Description("CatTargetEncoder")]
    CatTargetEncoder,

    [Description("CountVectorizer")]
    CountVectorizer,

    [Description("HashOneHotEncoder")]
    HashOneHotEncoder,

    [Description("LabelEncoder")]
    LabelEncoder,

    [Description("NaiveBayes")]
    NaiveBayes,

    [Description("OneHotEncoder")]
    OneHotEncoder,

    [Description("TextTargetEncoder")]
    TextTargetEncoder,

    [Description("TfIdf")]
    TfIdf,

    [Description("WoETargetEncoder")]
    WoETargetEncoder,

    [Description("WordEmbedding")]
    WordEmbedding,
}
