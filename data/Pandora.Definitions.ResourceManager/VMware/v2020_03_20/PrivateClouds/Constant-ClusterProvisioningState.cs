using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.VMware.v2020_03_20.PrivateClouds
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum ClusterProvisioningState
    {
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
}
