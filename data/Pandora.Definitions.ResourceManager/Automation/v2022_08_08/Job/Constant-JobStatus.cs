using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2022_08_08.Job;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum JobStatusConstant
{
    [Description("Activating")]
    Activating,

    [Description("Blocked")]
    Blocked,

    [Description("Completed")]
    Completed,

    [Description("Disconnected")]
    Disconnected,

    [Description("Failed")]
    Failed,

    [Description("New")]
    New,

    [Description("Removing")]
    Removing,

    [Description("Resuming")]
    Resuming,

    [Description("Running")]
    Running,

    [Description("Stopped")]
    Stopped,

    [Description("Stopping")]
    Stopping,

    [Description("Suspended")]
    Suspended,

    [Description("Suspending")]
    Suspending,
}
