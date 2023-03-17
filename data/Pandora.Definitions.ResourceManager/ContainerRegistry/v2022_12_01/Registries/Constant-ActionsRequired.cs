using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2022_12_01.Registries;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ActionsRequiredConstant
{
    [Description("None")]
    None,

    [Description("Recreate")]
    Recreate,
}
