using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_10_01.Schedule;

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

    [Description("PredictionDrift")]
    PredictionDrift,
}
