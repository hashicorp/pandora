using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_05_01.MachineLearningComputes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ClusterPurposeConstant
{
    [Description("DenseProd")]
    DenseProd,

    [Description("DevTest")]
    DevTest,

    [Description("FastProd")]
    FastProd,
}
