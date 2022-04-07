using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2021_09_01.PrivateEndpointConnections;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ActionsRequiredConstant
{
    [Description("None")]
    None,

    [Description("Recreate")]
    Recreate,
}
