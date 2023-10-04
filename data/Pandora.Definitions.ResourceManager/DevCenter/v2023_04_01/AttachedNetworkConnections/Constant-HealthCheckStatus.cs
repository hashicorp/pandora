using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DevCenter.v2023_04_01.AttachedNetworkConnections;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum HealthCheckStatusConstant
{
    [Description("Failed")]
    Failed,

    [Description("Passed")]
    Passed,

    [Description("Pending")]
    Pending,

    [Description("Running")]
    Running,

    [Description("Unknown")]
    Unknown,

    [Description("Warning")]
    Warning,
}
