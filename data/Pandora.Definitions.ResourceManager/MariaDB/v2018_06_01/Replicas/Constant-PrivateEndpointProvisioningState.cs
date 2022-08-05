using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MariaDB.v2018_06_01.Replicas;

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
