using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.VMware.v2022_05_01.WorkloadNetworks;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DnsServiceLogLevelEnumConstant
{
    [Description("DEBUG")]
    DEBUG,

    [Description("ERROR")]
    ERROR,

    [Description("FATAL")]
    FATAL,

    [Description("INFO")]
    INFO,

    [Description("WARNING")]
    WARNING,
}
