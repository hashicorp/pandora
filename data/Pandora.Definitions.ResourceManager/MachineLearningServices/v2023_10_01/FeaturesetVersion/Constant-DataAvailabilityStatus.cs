using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_10_01.FeaturesetVersion;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DataAvailabilityStatusConstant
{
    [Description("Complete")]
    Complete,

    [Description("Incomplete")]
    Incomplete,

    [Description("None")]
    None,

    [Description("Pending")]
    Pending,
}
