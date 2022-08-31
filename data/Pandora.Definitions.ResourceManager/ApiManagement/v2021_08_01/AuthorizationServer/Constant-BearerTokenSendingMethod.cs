using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.AuthorizationServer;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BearerTokenSendingMethodConstant
{
    [Description("authorizationHeader")]
    AuthorizationHeader,

    [Description("query")]
    Query,
}
