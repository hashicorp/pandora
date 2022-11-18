using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2022_10_01.Dimensions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ExternalCloudProviderTypeConstant
{
    [Description("externalBillingAccounts")]
    ExternalBillingAccounts,

    [Description("externalSubscriptions")]
    ExternalSubscriptions,
}
