using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PaloAltoNetworks.v2022_08_29.Firewalls;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LogTypeConstant
{
    [Description("AUDIT")]
    AUDIT,

    [Description("DECRYPTION")]
    DECRYPTION,

    [Description("DLP")]
    DLP,

    [Description("THREAT")]
    THREAT,

    [Description("TRAFFIC")]
    TRAFFIC,

    [Description("WILDFIRE")]
    WILDFIRE,
}
