using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2021_09_01.Registries;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LastModifiedByTypeConstant
{
    [Description("Application")]
    Application,

    [Description("Key")]
    Key,

    [Description("ManagedIdentity")]
    ManagedIdentity,

    [Description("User")]
    User,
}
