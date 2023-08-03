using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Maps.v2023_06_01.Accounts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IdentityTypeConstant
{
    [Description("delegatedResourceIdentity")]
    DelegatedResourceIdentity,

    [Description("systemAssignedIdentity")]
    SystemAssignedIdentity,

    [Description("userAssignedIdentity")]
    UserAssignedIdentity,
}
