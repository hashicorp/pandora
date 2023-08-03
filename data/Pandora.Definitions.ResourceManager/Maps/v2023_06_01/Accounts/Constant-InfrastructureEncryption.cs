using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Maps.v2023_06_01.Accounts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum InfrastructureEncryptionConstant
{
    [Description("disabled")]
    Disabled,

    [Description("enabled")]
    Enabled,
}
