using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.VMware.v2022_05_01.Clusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ClusterProvisioningStateConstant
{
    [Description("Canceled")]
    Canceled,

    [Description("Cancelled")]
    Cancelled,

    [Description("Deleting")]
    Deleting,

    [Description("Failed")]
    Failed,

    [Description("Succeeded")]
    Succeeded,

    [Description("Updating")]
    Updating,
}
