using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.StreamAnalytics.v2020_03_01.Clusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum JobStateConstant
{
    [Description("Created")]
    Created,

    [Description("Degraded")]
    Degraded,

    [Description("Deleting")]
    Deleting,

    [Description("Failed")]
    Failed,

    [Description("Restarting")]
    Restarting,

    [Description("Running")]
    Running,

    [Description("Scaling")]
    Scaling,

    [Description("Starting")]
    Starting,

    [Description("Stopped")]
    Stopped,

    [Description("Stopping")]
    Stopping,
}
