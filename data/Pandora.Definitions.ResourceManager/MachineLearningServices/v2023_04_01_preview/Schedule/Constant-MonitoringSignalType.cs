using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.Schedule;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MonitoringSignalTypeConstant
{
    [Description("Custom")]
    Custom,

    [Description("DataDrift")]
    DataDrift,

    [Description("DataQuality")]
    DataQuality,

    [Description("FeatureAttributionDrift")]
    FeatureAttributionDrift,

    [Description("ModelPerformance")]
    ModelPerformance,

    [Description("PredictionDrift")]
    PredictionDrift,
}
