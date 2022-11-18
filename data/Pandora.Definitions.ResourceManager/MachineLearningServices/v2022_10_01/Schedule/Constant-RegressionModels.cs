using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.Schedule;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RegressionModelsConstant
{
    [Description("DecisionTree")]
    DecisionTree,

    [Description("ElasticNet")]
    ElasticNet,

    [Description("ExtremeRandomTrees")]
    ExtremeRandomTrees,

    [Description("GradientBoosting")]
    GradientBoosting,

    [Description("KNN")]
    KNN,

    [Description("LassoLars")]
    LassoLars,

    [Description("LightGBM")]
    LightGBM,

    [Description("RandomForest")]
    RandomForest,

    [Description("SGD")]
    SGD,

    [Description("XGBoostRegressor")]
    XGBoostRegressor,
}
