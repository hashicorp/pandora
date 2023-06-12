using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServices.v2023_04_01.Vaults;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VaultPrivateEndpointStateConstant
{
    [Description("Enabled")]
    Enabled,

    [Description("None")]
    None,
}
