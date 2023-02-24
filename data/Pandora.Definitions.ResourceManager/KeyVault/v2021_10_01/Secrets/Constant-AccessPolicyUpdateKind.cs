using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.KeyVault.v2021_10_01.Secrets;

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
