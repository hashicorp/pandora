using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Insights.v2016_03_01.MetricDefinitions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum UnitConstant
{
    [Description("BitsPerSecond")]
    BitsPerSecond,

    [Description("ByteSeconds")]
    ByteSeconds,

    [Description("Bytes")]
    Bytes,

    [Description("BytesPerSecond")]
    BytesPerSecond,

    [Description("Cores")]
    Cores,

    [Description("Count")]
    Count,

    [Description("CountPerSecond")]
    CountPerSecond,

    [Description("MilliCores")]
    MilliCores,

    [Description("MilliSeconds")]
    MilliSeconds,

    [Description("NanoCores")]
    NanoCores,

    [Description("Percent")]
    Percent,

    [Description("Seconds")]
    Seconds,

    [Description("Unspecified")]
    Unspecified,
}
