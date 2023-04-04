using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ConnectedVmware.v2022_01_10_preview.VirtualMachineTemplates;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FirmwareTypeConstant
{
    [Description("bios")]
    Bios,

    [Description("efi")]
    Efi,
}
