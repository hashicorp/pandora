using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2021_06_01.AssessmentsMetadata;

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
