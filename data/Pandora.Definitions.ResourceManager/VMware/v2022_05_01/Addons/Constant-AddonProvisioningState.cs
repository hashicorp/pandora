using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.VMware.v2022_05_01.Addons;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AddonProvisioningStateConstant
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

    [Description("Succeeded")]
    Succeeded,

    [Description("Updating")]
    Updating,
}
