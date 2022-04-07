using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2021_09_01.Registries;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TrustPolicyTypeConstant
{
    [Description("Notary")]
    Notary,
}
