using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.TagResource;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BearerTokenSendingMethodsConstant
{
    [Description("authorizationHeader")]
    AuthorizationHeader,

    [Description("query")]
    Query,
}
