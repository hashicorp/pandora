using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Synapse.v2021_06_01.SqlPoolsTransparentDataEncryption;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TransparentDataEncryptionStatusConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
