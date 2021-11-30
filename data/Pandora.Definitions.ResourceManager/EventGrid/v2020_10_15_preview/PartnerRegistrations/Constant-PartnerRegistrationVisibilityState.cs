using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.PartnerRegistrations
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum PartnerRegistrationVisibilityStateConstant
    {
        [Description("GenerallyAvailable")]
        GenerallyAvailable,

        [Description("Hidden")]
        Hidden,

        [Description("PublicPreview")]
        PublicPreview,
    }
}
