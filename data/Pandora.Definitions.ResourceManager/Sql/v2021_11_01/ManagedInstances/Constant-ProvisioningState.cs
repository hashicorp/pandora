using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.ManagedInstances;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProvisioningStateConstant
{
    [Description("Accepted")]
    Accepted,

    [Description("Canceled")]
    Canceled,

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

    [Description("NotSpecified")]
    NotSpecified,

    [Description("Registering")]
    Registering,

    [Description("Running")]
    Running,

    [Description("Succeeded")]
    Succeeded,

    [Description("TimedOut")]
    TimedOut,

    [Description("Unknown")]
    Unknown,

    [Description("Unrecognized")]
    Unrecognized,

    [Description("Updating")]
    Updating,
}
