using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.Schedule;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ForecastingModelsConstant
{
    [Description("Arimax")]
    Arimax,

    [Description("AutoArima")]
    AutoArima,

    [Description("Average")]
    Average,

    [Description("DecisionTree")]
    DecisionTree,

    [Description("ElasticNet")]
    ElasticNet,

    [Description("ExponentialSmoothing")]
    ExponentialSmoothing,

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

    [Description("Naive")]
    Naive,

    [Description("Prophet")]
    Prophet,

    [Description("RandomForest")]
    RandomForest,

    [Description("SGD")]
    SGD,

    [Description("SeasonalAverage")]
    SeasonalAverage,

    [Description("SeasonalNaive")]
    SeasonalNaive,

    [Description("TCNForecaster")]
    TCNForecaster,

    [Description("XGBoostRegressor")]
    XGBoostRegressor,
}
