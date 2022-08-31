using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2021_11_01.VirtualMachines;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PatchInstallationStateConstant
{
    [Description("Excluded")]
    Excluded,

    [Description("Failed")]
    Failed,

    [Description("Installed")]
    Installed,

    [Description("NotSelected")]
    NotSelected,

    [Description("Pending")]
    Pending,

    [Description("Unknown")]
    Unknown,
}
