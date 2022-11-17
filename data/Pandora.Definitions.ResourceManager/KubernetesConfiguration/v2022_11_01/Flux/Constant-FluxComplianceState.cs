using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.KubernetesConfiguration.v2022_11_01.Flux;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FluxComplianceStateConstant
{
    [Description("Compliant")]
    Compliant,

    [Description("Non-Compliant")]
    NonNegativeCompliant,

    [Description("Pending")]
    Pending,

    [Description("Suspended")]
    Suspended,

    [Description("Unknown")]
    Unknown,
}
