using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.ProductApi;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BearerTokenSendingMethodsConstant
{
    [Description("authorizationHeader")]
    AuthorizationHeader,

    [Description("query")]
    Query,
}
