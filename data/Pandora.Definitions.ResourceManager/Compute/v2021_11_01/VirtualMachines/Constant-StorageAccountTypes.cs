using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2021_11_01.VirtualMachines;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StorageAccountTypesConstant
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
