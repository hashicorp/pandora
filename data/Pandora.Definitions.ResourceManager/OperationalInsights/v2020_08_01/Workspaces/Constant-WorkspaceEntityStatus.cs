using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2020_08_01.Workspaces;

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
