using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.EventChannels
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum EventChannelProvisioningStateConstant
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
