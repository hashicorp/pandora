using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ConnectedVmware.v2022_01_10_preview.VirtualMachines;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VMGuestPatchClassificationWindowsConstant
{
    [Description("Critical")]
    Critical,

    [Description("Definition")]
    Definition,

    [Description("FeaturePack")]
    FeaturePack,

    [Description("Security")]
    Security,

    [Description("ServicePack")]
    ServicePack,

    [Description("Tools")]
    Tools,

    [Description("UpdateRollUp")]
    UpdateRollUp,

    [Description("Updates")]
    Updates,
}
