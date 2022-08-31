using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.KubernetesConfiguration.v2022_03_01.FluxConfiguration;

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
