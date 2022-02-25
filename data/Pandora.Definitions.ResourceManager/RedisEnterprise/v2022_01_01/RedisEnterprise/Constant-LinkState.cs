using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RedisEnterprise.v2022_01_01.RedisEnterprise;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LinkStateConstant
{
    [Description("LinkFailed")]
    LinkFailed,

    [Description("Linked")]
    Linked,

    [Description("Linking")]
    Linking,

    [Description("UnlinkFailed")]
    UnlinkFailed,

    [Description("Unlinking")]
    Unlinking,
}
