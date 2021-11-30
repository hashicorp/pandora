using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.PartnerTopics
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum PartnerTopicActivationStateConstant
    {
        [Description("Activated")]
        Activated,

        [Description("Deactivated")]
        Deactivated,

        [Description("NeverActivated")]
        NeverActivated,
    }
}
