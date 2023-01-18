using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.WorkflowTriggers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WorkflowTriggerProvisioningStateConstant
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

    [Description("Moving")]
    Moving,

    [Description("NotSpecified")]
    NotSpecified,

    [Description("Ready")]
    Ready,

    [Description("Registered")]
    Registered,

    [Description("Registering")]
    Registering,

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
}
