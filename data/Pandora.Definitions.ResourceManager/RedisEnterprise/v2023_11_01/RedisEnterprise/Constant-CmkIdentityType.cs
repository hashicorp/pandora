using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RedisEnterprise.v2023_11_01.RedisEnterprise;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CmkIdentityTypeConstant
{
    [Description("systemAssignedIdentity")]
    SystemAssignedIdentity,

    [Description("userAssignedIdentity")]
    UserAssignedIdentity,
}
