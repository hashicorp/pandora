using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ServiceLinker.v2022_05_01.Links;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AzureResourceTypeConstant
{
    [Description("KeyVault")]
    KeyVault,
}
