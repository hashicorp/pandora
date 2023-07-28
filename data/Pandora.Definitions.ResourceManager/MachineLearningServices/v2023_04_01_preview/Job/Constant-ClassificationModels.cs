using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.Job;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ClassificationModelsConstant
{
    [Description("BernoulliNaiveBayes")]
    BernoulliNaiveBayes,

    [Description("DecisionTree")]
    DecisionTree,

    [Description("ExtremeRandomTrees")]
    ExtremeRandomTrees,

    [Description("GradientBoosting")]
    GradientBoosting,

    [Description("KNN")]
    KNN,

    [Description("LightGBM")]
    LightGBM,

    [Description("LinearSVM")]
    LinearSVM,

    [Description("LogisticRegression")]
    LogisticRegression,

    [Description("MultinomialNaiveBayes")]
    MultinomialNaiveBayes,

    [Description("RandomForest")]
    RandomForest,

    [Description("SGD")]
    SGD,

    [Description("SVM")]
    SVM,

    [Description("XGBoostClassifier")]
    XGBoostClassifier,
}
