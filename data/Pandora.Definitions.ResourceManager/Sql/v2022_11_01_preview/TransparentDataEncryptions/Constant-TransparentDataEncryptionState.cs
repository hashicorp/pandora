using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.TransparentDataEncryptions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TransparentDataEncryptionStateConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
