using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2021_07_01.VirtualMachineImages;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VMDiskTypesConstant
{
    [Description("None")]
    None,

    [Description("Unmanaged")]
    Unmanaged,
}
