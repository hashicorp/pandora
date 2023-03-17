using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.KeyVault.v2023_02_01.ManagedHsms;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ReasonConstant
{
    [Description("AccountNameInvalid")]
    AccountNameInvalid,

    [Description("AlreadyExists")]
    AlreadyExists,
}
