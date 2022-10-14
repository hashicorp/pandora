using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.VMware.v2021_12_01.GlobalReachConnections;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum GlobalReachConnectionProvisioningStateConstant
{
    [Description("Failed")]
    Failed,

    [Description("Succeeded")]
    Succeeded,

    [Description("Updating")]
    Updating,
}
