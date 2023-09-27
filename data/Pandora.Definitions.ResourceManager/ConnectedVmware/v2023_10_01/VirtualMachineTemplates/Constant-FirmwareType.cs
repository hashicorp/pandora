using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ConnectedVmware.v2023_10_01.VirtualMachineTemplates;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FirmwareTypeConstant
{
    [Description("bios")]
    Bios,

    [Description("efi")]
    Efi,
}
