using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ConnectedVmware.v2022_01_10_preview.VirtualMachines;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VMGuestPatchRebootStatusConstant
{
    [Description("Completed")]
    Completed,

    [Description("Failed")]
    Failed,

    [Description("NotNeeded")]
    NotNeeded,

    [Description("Required")]
    Required,

    [Description("Started")]
    Started,

    [Description("Unknown")]
    Unknown,
}
