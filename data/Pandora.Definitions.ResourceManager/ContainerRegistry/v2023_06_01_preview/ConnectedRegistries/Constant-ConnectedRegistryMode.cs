using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2023_06_01_preview.ConnectedRegistries;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ConnectedRegistryModeConstant
{
    [Description("Mirror")]
    Mirror,

    [Description("ReadOnly")]
    ReadOnly,

    [Description("ReadWrite")]
    ReadWrite,

    [Description("Registry")]
    Registry,
}
