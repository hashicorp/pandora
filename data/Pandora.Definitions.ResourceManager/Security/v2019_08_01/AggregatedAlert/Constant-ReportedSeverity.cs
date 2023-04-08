using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2019_08_01.AggregatedAlert;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ReportedSeverityConstant
{
    [Description("High")]
    High,

    [Description("Informational")]
    Informational,

    [Description("Low")]
    Low,

    [Description("Medium")]
    Medium,
}
