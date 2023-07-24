using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.WorkflowRuns;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WorkflowStatusConstant
{
    [Description("Aborted")]
    Aborted,

    [Description("Cancelled")]
    Cancelled,

    [Description("Failed")]
    Failed,

    [Description("Faulted")]
    Faulted,

    [Description("Ignored")]
    Ignored,

    [Description("NotSpecified")]
    NotSpecified,

    [Description("Paused")]
    Paused,

    [Description("Running")]
    Running,

    [Description("Skipped")]
    Skipped,

    [Description("Succeeded")]
    Succeeded,

    [Description("Suspended")]
    Suspended,

    [Description("TimedOut")]
    TimedOut,

    [Description("Waiting")]
    Waiting,
}
