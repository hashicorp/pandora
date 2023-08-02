using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.Schedule;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MonitoringFeatureFilterTypeConstant
{
    [Description("AllFeatures")]
    AllFeatures,

    [Description("FeatureSubset")]
    FeatureSubset,

    [Description("TopNByAttribution")]
    TopNByAttribution,
}
