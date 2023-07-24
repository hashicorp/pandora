using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.Workflows;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WorkflowProvisioningStateConstant
{
    [Description("Accepted")]
    Accepted,

    [Description("Canceled")]
    Canceled,

    [Description("Completed")]
    Completed,

    [Description("Created")]
    Created,

    [Description("Creating")]
    Creating,

    [Description("Deleted")]
    Deleted,

    [Description("Deleting")]
    Deleting,

    [Description("Failed")]
    Failed,

    [Description("InProgress")]
    InProgress,

    [Description("Moving")]
    Moving,

    [Description("NotSpecified")]
    NotSpecified,

    [Description("Pending")]
    Pending,

    [Description("Ready")]
    Ready,

    [Description("Registered")]
    Registered,

    [Description("Registering")]
    Registering,

    [Description("Renewing")]
    Renewing,

    [Description("Running")]
    Running,

    [Description("Succeeded")]
    Succeeded,

    [Description("Unregistered")]
    Unregistered,

    [Description("Unregistering")]
    Unregistering,

    [Description("Updating")]
    Updating,

    [Description("Waiting")]
    Waiting,
}
