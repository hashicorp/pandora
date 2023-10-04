using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ElasticSan.v2023_01_01.ElasticSanSkus;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SkuNameConstant
{
    [Description("Premium_LRS")]
    PremiumLRS,

    [Description("Premium_ZRS")]
    PremiumZRS,
}
