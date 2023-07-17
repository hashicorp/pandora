using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2022_06_15.PartnerTopics;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PartnerTopicProvisioningStateConstant
{
    [Description("Canceled")]
    Canceled,

    [Description("Creating")]
    Creating,

    [Description("Deleting")]
    Deleting,

    [Description("Failed")]
    Failed,

    [Description("IdleDueToMirroredChannelResourceDeletion")]
    IdleDueToMirroredChannelResourceDeletion,

    [Description("Succeeded")]
    Succeeded,

    [Description("Updating")]
    Updating,
}
