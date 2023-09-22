using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NetApp.v2022_11_01_preview.Backups;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MirrorStateConstant
{
    [Description("Broken")]
    Broken,

    [Description("Mirrored")]
    Mirrored,

    [Description("Uninitialized")]
    Uninitialized,
}
