using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DeviceUpdate.v2022_10_01.Deviceupdates;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProvisioningStateConstant
{
    [Description("Accepted")]
    Accepted,

    [Description("Canceled")]
    Canceled,

    [Description("Creating")]
    Creating,

    [Description("Deleted")]
    Deleted,

    [Description("Failed")]
    Failed,

    [Description("Succeeded")]
    Succeeded,
}
