using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.Recommendations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ChannelsConstant
{
    [Description("All")]
    All,

    [Description("Api")]
    Api,

    [Description("Email")]
    Email,

    [Description("Notification")]
    Notification,

    [Description("Webhook")]
    Webhook,
}
