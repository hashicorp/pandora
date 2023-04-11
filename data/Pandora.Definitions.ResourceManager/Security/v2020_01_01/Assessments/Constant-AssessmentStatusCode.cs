using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2020_01_01.Assessments;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AssessmentStatusCodeConstant
{
    [Description("Healthy")]
    Healthy,

    [Description("NotApplicable")]
    NotApplicable,

    [Description("Unhealthy")]
    Unhealthy,
}
