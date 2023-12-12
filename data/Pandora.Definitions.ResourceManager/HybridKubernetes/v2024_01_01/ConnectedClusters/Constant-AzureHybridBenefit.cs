using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.HybridKubernetes.v2024_01_01.ConnectedClusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AzureHybridBenefitConstant
{
    [Description("False")]
    False,

    [Description("NotApplicable")]
    NotApplicable,

    [Description("True")]
    True,
}
