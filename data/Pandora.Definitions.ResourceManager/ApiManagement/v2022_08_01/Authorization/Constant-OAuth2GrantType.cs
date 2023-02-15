using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.Authorization;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OAuth2GrantTypeConstant
{
    [Description("AuthorizationCode")]
    AuthorizationCode,

    [Description("ClientCredentials")]
    ClientCredentials,
}
