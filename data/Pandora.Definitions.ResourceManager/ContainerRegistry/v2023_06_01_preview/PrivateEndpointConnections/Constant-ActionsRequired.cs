using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2023_06_01_preview.PrivateEndpointConnections;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ActionsRequiredConstant
{
    [Description("None")]
    None,

    [Description("Recreate")]
    Recreate,
}
