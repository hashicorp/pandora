using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2021_05_01.NodeType;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ManagedResourceProvisioningStateConstant
{
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

    [Description("None")]
    None,

    [Description("Other")]
    Other,

    [Description("Succeeded")]
    Succeeded,

    [Description("Updating")]
    Updating,
}
