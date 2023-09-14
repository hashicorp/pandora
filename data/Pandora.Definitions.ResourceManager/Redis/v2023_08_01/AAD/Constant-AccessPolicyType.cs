using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Redis.v2023_08_01.AAD;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AccessPolicyTypeConstant
{
    [Description("BuiltIn")]
    BuiltIn,

    [Description("Custom")]
    Custom,
}
