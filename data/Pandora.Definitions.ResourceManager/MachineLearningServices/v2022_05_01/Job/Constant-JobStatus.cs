using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_05_01.Job;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum JobStatusConstant
{
    [Description("CancelRequested")]
    CancelRequested,

    [Description("Canceled")]
    Canceled,

    [Description("Completed")]
    Completed,

    [Description("Failed")]
    Failed,

    [Description("Finalizing")]
    Finalizing,

    [Description("NotResponding")]
    NotResponding,

    [Description("NotStarted")]
    NotStarted,

    [Description("Paused")]
    Paused,

    [Description("Preparing")]
    Preparing,

    [Description("Provisioning")]
    Provisioning,

    [Description("Queued")]
    Queued,

    [Description("Running")]
    Running,

    [Description("Starting")]
    Starting,

    [Description("Unknown")]
    Unknown,
}
