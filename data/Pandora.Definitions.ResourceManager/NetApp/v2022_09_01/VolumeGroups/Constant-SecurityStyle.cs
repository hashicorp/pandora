using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NetApp.v2022_09_01.VolumeGroups;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecurityStyleConstant
{
    [Description("ntfs")]
    Ntfs,

    [Description("unix")]
    Unix,
}
