using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.NotificationChannels;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NotificationChannelEventTypeConstant
{
    [Description("AutoShutdown")]
    AutoShutdown,

    [Description("Cost")]
    Cost,
}
