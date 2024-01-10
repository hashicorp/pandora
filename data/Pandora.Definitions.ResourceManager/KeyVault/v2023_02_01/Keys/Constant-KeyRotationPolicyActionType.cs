using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.KeyVault.v2023_02_01.Keys;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KeyRotationPolicyActionTypeConstant
{
    [Description("Notify")]
    Notify,

    [Description("Rotate")]
    Rotate,
}
