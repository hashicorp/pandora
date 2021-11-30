using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.EventChannels
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum PartnerTopicReadinessStateConstant
    {
        [Description("ActivatedByUser")]
        ActivatedByUser,

        [Description("DeactivatedByUser")]
        DeactivatedByUser,

        [Description("DeletedByUser")]
        DeletedByUser,

        [Description("NotActivatedByUserYet")]
        NotActivatedByUserYet,
    }
}
