using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Bot.v2021_03_01.Channel;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KeyConstant
{
    [Description("key1")]
    KeyOne,

    [Description("key2")]
    KeyTwo,
}
