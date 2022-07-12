using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2021_08_01.Disks;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DiskStorageAccountTypesConstant
{
    [Description("Premium_LRS")]
    PremiumLRS,

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
