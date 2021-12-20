using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.StoragePool.v2021_08_01.ResourceSkus
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum ResourceSkuRestrictionsTypeConstant
    {
        [Description("Location")]
        Location,

        [Description("Zone")]
        Zone,
    }
}
