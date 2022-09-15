using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2021_07_01.CommunityGalleryImages;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OperatingSystemStateTypesConstant
{
    [Description("Generalized")]
    Generalized,

    [Description("Specialized")]
    Specialized,
}
