using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NetApp.v2021_10_01.VolumesReplication;

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
