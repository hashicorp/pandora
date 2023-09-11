using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.AuthorizationServer;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum GrantTypeConstant
{
    [Description("authorizationCode")]
    AuthorizationCode,

    [Description("clientCredentials")]
    ClientCredentials,

    [Description("implicit")]
    Implicit,

    [Description("resourceOwnerPassword")]
    ResourceOwnerPassword,
}
