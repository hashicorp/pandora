using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2023_09_01.DeletedWorkspaces;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WorkspaceEntityStatusConstant
{
    [Description("Canceled")]
    Canceled,

    [Description("Creating")]
    Creating,

    [Description("Deleting")]
    Deleting,

    [Description("Failed")]
    Failed,

    [Description("ProvisioningAccount")]
    ProvisioningAccount,

    [Description("Succeeded")]
    Succeeded,

    [Description("Updating")]
    Updating,
}
