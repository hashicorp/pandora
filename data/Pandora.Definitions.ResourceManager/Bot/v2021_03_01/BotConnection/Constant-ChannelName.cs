using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Bot.v2021_03_01.BotConnection;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ChannelNameConstant
{
    [Description("AlexaChannel")]
    AlexaChannel,

    [Description("DirectLineChannel")]
    DirectLineChannel,

    [Description("DirectLineSpeechChannel")]
    DirectLineSpeechChannel,

    [Description("EmailChannel")]
    EmailChannel,

    [Description("FacebookChannel")]
    FacebookChannel,

    [Description("KikChannel")]
    KikChannel,

    [Description("LineChannel")]
    LineChannel,

    [Description("MsTeamsChannel")]
    MsTeamsChannel,

    [Description("SkypeChannel")]
    SkypeChannel,

    [Description("SlackChannel")]
    SlackChannel,

    [Description("SmsChannel")]
    SmsChannel,

    [Description("TelegramChannel")]
    TelegramChannel,

    [Description("WebChatChannel")]
    WebChatChannel,
}
