using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.VMware.v2022_05_01.PrivateClouds;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PrivateCloudProvisioningStateConstant
{
    [Description("Building")]
    Building,

    [Description("Canceled")]
    Canceled,

    [Description("Cancelled")]
    Cancelled,

    [Description("Deleting")]
    Deleting,

    [Description("Failed")]
    Failed,

    [Description("Pending")]
    Pending,

    [Description("Succeeded")]
    Succeeded,

    [Description("Updating")]
    Updating,
}
