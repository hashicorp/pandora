using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Workloads.v2023_04_01.SAPApplicationServerInstances;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SAPHealthStateConstant
{
    [Description("Degraded")]
    Degraded,

    [Description("Healthy")]
    Healthy,

    [Description("Unhealthy")]
    Unhealthy,

    [Description("Unknown")]
    Unknown,
}
