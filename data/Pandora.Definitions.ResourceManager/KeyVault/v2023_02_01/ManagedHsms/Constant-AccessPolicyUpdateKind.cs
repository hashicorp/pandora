using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.KeyVault.v2023_02_01.ManagedHsms;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AccessPolicyUpdateKindConstant
{
    [Description("add")]
    Add,

    [Description("remove")]
    Remove,

    [Description("replace")]
    Replace,
}
