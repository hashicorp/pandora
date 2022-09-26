using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_01.RestorePointCollections;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StorageAccountTypesConstant
{
    [Description("Premium_LRS")]
    PremiumLRS,

    [Description("PremiumV2_LRS")]
    PremiumVTwoLRS,

    [Description("Premium_ZRS")]
    PremiumZRS,

    [Description("Standard_LRS")]
    StandardLRS,

    [Description("StandardSSD_LRS")]
    StandardSSDLRS,

    [Description("StandardSSD_ZRS")]
    StandardSSDZRS,

    [Description("UltraSSD_LRS")]
    UltraSSDLRS,
}
