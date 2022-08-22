using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.PolicyDescription;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PolicyScopeContractConstant
{
    [Description("All")]
    All,

    [Description("Api")]
    Api,

    [Description("Operation")]
    Operation,

    [Description("Product")]
    Product,

    [Description("Tenant")]
    Tenant,
}
