using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.KeyVault.v2022_11_01.ManagedHsms;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ActivationStatusConstant
{
    [Description("Active")]
    Active,

    [Description("Failed")]
    Failed,

    [Description("NotActivated")]
    NotActivated,

    [Description("Unknown")]
    Unknown,
}
