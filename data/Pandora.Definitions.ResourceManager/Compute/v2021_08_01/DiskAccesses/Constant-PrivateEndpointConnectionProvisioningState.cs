using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2021_08_01.DiskAccesses;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PrivateEndpointConnectionProvisioningStateConstant
{
    [Description("Creating")]
    Creating,

    [Description("Deleting")]
    Deleting,

    [Description("Failed")]
    Failed,

    [Description("Succeeded")]
    Succeeded,
}
