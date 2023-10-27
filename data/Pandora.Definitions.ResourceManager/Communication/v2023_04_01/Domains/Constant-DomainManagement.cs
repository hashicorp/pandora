using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Communication.v2023_04_01.Domains;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DomainManagementConstant
{
    [Description("AzureManaged")]
    AzureManaged,

    [Description("CustomerManaged")]
    CustomerManaged,

    [Description("CustomerManagedInExchangeOnline")]
    CustomerManagedInExchangeOnline,
}
