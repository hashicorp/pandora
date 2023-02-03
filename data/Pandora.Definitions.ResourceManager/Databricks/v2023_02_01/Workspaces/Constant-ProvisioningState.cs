using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Databricks.v2023_02_01.Workspaces;

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

    [Description("Ready")]
    Ready,

    [Description("Running")]
    Running,

    [Description("Succeeded")]
    Succeeded,

    [Description("Updating")]
    Updating,
}
