using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ConnectedVmware.v2022_01_10_preview.VirtualMachines;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IPAddressAllocationMethodConstant
{
    [Description("dynamic")]
    Dynamic,

    [Description("linklayer")]
    Linklayer,

    [Description("other")]
    Other,

    [Description("random")]
    Random,

    [Description("static")]
    Static,

    [Description("unset")]
    Unset,
}
