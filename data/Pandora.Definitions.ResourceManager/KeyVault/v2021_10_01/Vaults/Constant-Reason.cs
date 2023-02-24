using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.KeyVault.v2021_10_01.Vaults;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ReasonConstant
{
    [Description("AccountNameInvalid")]
    AccountNameInvalid,

    [Description("AlreadyExists")]
    AlreadyExists,
}
