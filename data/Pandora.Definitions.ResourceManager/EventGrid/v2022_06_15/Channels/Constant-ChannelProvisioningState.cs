using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2022_06_15.Channels;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ChannelProvisioningStateConstant
{
    [Description("Canceled")]
    Canceled,

    [Description("Creating")]
    Creating,

    [Description("Deleting")]
    Deleting,

    [Description("Failed")]
    Failed,

    [Description("IdleDueToMirroredPartnerTopicDeletion")]
    IdleDueToMirroredPartnerTopicDeletion,

    [Description("Succeeded")]
    Succeeded,

    [Description("Updating")]
    Updating,
}
