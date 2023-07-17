using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2022_06_15.PartnerTopics;

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
