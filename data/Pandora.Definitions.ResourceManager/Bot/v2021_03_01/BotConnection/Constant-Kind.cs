using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Bot.v2021_03_01.BotConnection;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KindConstant
{
    [Description("azurebot")]
    Azurebot,

    [Description("bot")]
    Bot,

    [Description("designer")]
    Designer,

    [Description("function")]
    Function,

    [Description("sdk")]
    Sdk,
}
