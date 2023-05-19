using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_03.GalleryImageVersions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PolicyViolationCategoryConstant
{
    [Description("CopyrightValidation")]
    CopyrightValidation,

    [Description("IpTheft")]
    IPTheft,

    [Description("ImageFlaggedUnsafe")]
    ImageFlaggedUnsafe,

    [Description("Other")]
    Other,
}
