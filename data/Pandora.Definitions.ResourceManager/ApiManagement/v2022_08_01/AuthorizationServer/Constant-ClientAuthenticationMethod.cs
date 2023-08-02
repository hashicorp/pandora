using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.AuthorizationServer;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ClientAuthenticationMethodConstant
{
    [Description("Basic")]
    Basic,

    [Description("Body")]
    Body,
}
