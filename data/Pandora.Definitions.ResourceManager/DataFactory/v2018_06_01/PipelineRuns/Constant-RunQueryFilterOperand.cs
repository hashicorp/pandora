using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.PipelineRuns;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RunQueryFilterOperandConstant
{
    [Description("ActivityName")]
    ActivityName,

    [Description("ActivityRunEnd")]
    ActivityRunEnd,

    [Description("ActivityRunStart")]
    ActivityRunStart,

    [Description("ActivityType")]
    ActivityType,

    [Description("LatestOnly")]
    LatestOnly,

    [Description("PipelineName")]
    PipelineName,

    [Description("RunEnd")]
    RunEnd,

    [Description("RunGroupId")]
    RunGroupId,

    [Description("RunStart")]
    RunStart,

    [Description("Status")]
    Status,

    [Description("TriggerName")]
    TriggerName,

    [Description("TriggerRunTimestamp")]
    TriggerRunTimestamp,
}
