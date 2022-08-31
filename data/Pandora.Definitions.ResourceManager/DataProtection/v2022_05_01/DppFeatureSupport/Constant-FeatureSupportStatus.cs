using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataProtection.v2022_05_01.DppFeatureSupport;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FeatureSupportStatusConstant
{
    [Description("AlphaPreview")]
    AlphaPreview,

    [Description("GenerallyAvailable")]
    GenerallyAvailable,

    [Description("Invalid")]
    Invalid,

    [Description("NotSupported")]
    NotSupported,

    [Description("PrivatePreview")]
    PrivatePreview,

    [Description("PublicPreview")]
    PublicPreview,
}
