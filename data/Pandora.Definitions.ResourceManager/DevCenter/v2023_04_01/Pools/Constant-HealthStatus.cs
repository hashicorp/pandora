using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DevCenter.v2023_04_01.Pools;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum HealthStatusConstant
{
    [Description("Healthy")]
    Healthy,

    [Description("Pending")]
    Pending,

    [Description("Unhealthy")]
    Unhealthy,

    [Description("Unknown")]
    Unknown,

    [Description("Warning")]
    Warning,
}
