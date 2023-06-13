using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.Servers;

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
