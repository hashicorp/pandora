using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Workloads.v2023_04_01.SapLandscapeMonitor;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SapLandscapeMonitorProvisioningStateConstant
{
    [Description("Accepted")]
    Accepted,

    [Description("Canceled")]
    Canceled,

    [Description("Created")]
    Created,

    [Description("Failed")]
    Failed,

    [Description("Succeeded")]
    Succeeded,
}
