using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.Schedule;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NumericalDataDriftMetricConstant
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
