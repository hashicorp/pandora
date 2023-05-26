using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.PrivateEndpointConnections;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PrivateEndpointProvisioningStateConstant
{
    [Description("Approving")]
    Approving,

    [Description("Dropping")]
    Dropping,

    [Description("Failed")]
    Failed,

    [Description("Ready")]
    Ready,

    [Description("Rejecting")]
    Rejecting,
}
