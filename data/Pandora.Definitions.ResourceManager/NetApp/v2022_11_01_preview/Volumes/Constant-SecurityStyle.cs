using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NetApp.v2022_11_01_preview.Volumes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecurityStyleConstant
{
    [Description("ntfs")]
    Ntfs,

    [Description("unix")]
    Unix,
}
