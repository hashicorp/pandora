using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_01.VirtualMachines;

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
