using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PolicyInsights.v2022_09_01.Attestations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ComplianceStateConstant
{
    [Description("Compliant")]
    Compliant,

    [Description("NonCompliant")]
    NonCompliant,

    [Description("Unknown")]
    Unknown,
}
