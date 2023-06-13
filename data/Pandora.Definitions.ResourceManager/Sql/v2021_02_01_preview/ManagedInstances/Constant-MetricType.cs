using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.ManagedInstances;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MetricTypeConstant
{
    [Description("cpu")]
    Cpu,

    [Description("dtu")]
    Dtu,

    [Description("duration")]
    Duration,

    [Description("io")]
    Io,

    [Description("logIo")]
    LogIo,
}
