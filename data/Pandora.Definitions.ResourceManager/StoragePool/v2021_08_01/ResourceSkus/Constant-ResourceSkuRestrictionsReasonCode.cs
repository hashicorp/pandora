using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.StoragePool.v2021_08_01.ResourceSkus
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum ResourceSkuRestrictionsReasonCodeConstant
    {
        [Description("NotAvailableForSubscription")]
        NotAvailableForSubscription,

        [Description("QuotaId")]
        QuotaId,
    }
}
