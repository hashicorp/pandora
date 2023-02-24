using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.Triggerruns;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RunQueryOrderByFieldConstant
{
    [Description("ActivityName")]
    ActivityName,

    [Description("ActivityRunEnd")]
    ActivityRunEnd,

    [Description("ActivityRunStart")]
    ActivityRunStart,

    [Description("PipelineName")]
    PipelineName,

    [Description("RunEnd")]
    RunEnd,

    [Description("RunStart")]
    RunStart,

    [Description("Status")]
    Status,

    [Description("TriggerName")]
    TriggerName,

    [Description("TriggerRunTimestamp")]
    TriggerRunTimestamp,
}
