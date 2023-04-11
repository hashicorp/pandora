using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2019_01_01_preview.SubAssessments;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SeverityConstant
{
    [Description("High")]
    High,

    [Description("Low")]
    Low,

    [Description("Medium")]
    Medium,
}
