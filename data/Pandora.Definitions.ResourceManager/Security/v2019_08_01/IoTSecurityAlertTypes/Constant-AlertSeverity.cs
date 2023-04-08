using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2019_08_01.IoTSecurityAlertTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AlertSeverityConstant
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
