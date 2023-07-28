using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.Schedule;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StackMetaLearnerTypeConstant
{
    [Description("ElasticNet")]
    ElasticNet,

    [Description("ElasticNetCV")]
    ElasticNetCV,

    [Description("LightGBMClassifier")]
    LightGBMClassifier,

    [Description("LightGBMRegressor")]
    LightGBMRegressor,

    [Description("LinearRegression")]
    LinearRegression,

    [Description("LogisticRegression")]
    LogisticRegression,

    [Description("LogisticRegressionCV")]
    LogisticRegressionCV,

    [Description("None")]
    None,
}
