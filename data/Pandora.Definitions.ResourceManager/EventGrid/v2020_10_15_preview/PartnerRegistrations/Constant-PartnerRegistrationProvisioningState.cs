using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.PartnerRegistrations
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum PartnerRegistrationProvisioningStateConstant
    {
        [Description("Canceled")]
        Canceled,

        [Description("Creating")]
        Creating,

        [Description("Deleting")]
        Deleting,

        [Description("Failed")]
        Failed,

        [Description("Succeeded")]
        Succeeded,

        [Description("Updating")]
        Updating,
    }
}
