using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_10_01.Schedule;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NumericalPredictionDriftMetricConstant
{
    [Description("JensenShannonDistance")]
    JensenShannonDistance,

    [Description("NormalizedWassersteinDistance")]
    NormalizedWassersteinDistance,

    [Description("PopulationStabilityIndex")]
    PopulationStabilityIndex,

    [Description("TwoSampleKolmogorovSmirnovTest")]
    TwoSampleKolmogorovSmirnovTest,
}
