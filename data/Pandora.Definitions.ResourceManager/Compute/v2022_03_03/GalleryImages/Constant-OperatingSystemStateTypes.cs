using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_03.GalleryImages;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OperatingSystemStateTypesConstant
{
    [Description("Generalized")]
    Generalized,

    [Description("Specialized")]
    Specialized,
}
