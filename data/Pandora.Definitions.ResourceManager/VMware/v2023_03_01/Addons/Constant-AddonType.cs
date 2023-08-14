using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.VMware.v2023_03_01.Addons;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AddonTypeConstant
{
    [Description("Arc")]
    Arc,

    [Description("HCX")]
    HCX,

    [Description("SRM")]
    SRM,

    [Description("VR")]
    VR,
}
