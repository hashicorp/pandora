using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NetApp.v2022_01_01.Volumes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecurityStyleConstant
{
    [Description("ntfs")]
    Ntfs,

    [Description("unix")]
    Unix,
}
