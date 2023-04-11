using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2020_01_01.Assessments;

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
