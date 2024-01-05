using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NetApp.v2023_07_01.Restore;

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
