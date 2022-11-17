using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Storage.v2022_09_01.Skus;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SkuNameConstant
{
    [Description("Premium_LRS")]
    PremiumLRS,

    [Description("Premium_ZRS")]
    PremiumZRS,

    [Description("Standard_GRS")]
    StandardGRS,

    [Description("Standard_GZRS")]
    StandardGZRS,

    [Description("Standard_LRS")]
    StandardLRS,

    [Description("Standard_RAGRS")]
    StandardRAGRS,

    [Description("Standard_RAGZRS")]
    StandardRAGZRS,

    [Description("Standard_ZRS")]
    StandardZRS,
}
