using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Redis.v2023_08_01.Redis;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum UpdateChannelConstant
{
    [Description("Preview")]
    Preview,

    [Description("Stable")]
    Stable,
}
