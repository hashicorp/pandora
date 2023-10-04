using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ConnectedVmware.v2023_10_01.VirtualMachineTemplates;

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
