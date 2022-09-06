using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ElasticSan.v2021_11_20_preview.ElasticSan;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SkuNameConstant
{
    [Description("Premium_LRS")]
    PremiumLRS,

    [Description("Premium_ZRS")]
    PremiumZRS,
}
