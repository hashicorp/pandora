using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.VirtualMachines;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VirtualMachineCreationSourceConstant
{
    [Description("FromCustomImage")]
    FromCustomImage,

    [Description("FromGalleryImage")]
    FromGalleryImage,

    [Description("FromSharedGalleryImage")]
    FromSharedGalleryImage,
}
