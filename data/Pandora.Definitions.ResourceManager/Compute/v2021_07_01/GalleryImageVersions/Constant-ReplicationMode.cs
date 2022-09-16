using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2021_07_01.GalleryImageVersions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ReplicationModeConstant
{
    [Description("Full")]
    Full,

    [Description("Shallow")]
    Shallow,
}
