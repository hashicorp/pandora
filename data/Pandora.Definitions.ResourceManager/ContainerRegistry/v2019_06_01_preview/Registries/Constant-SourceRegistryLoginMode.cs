using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2019_06_01_preview.Registries;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SourceRegistryLoginModeConstant
{
    [Description("Default")]
    Default,

    [Description("None")]
    None,
}
