using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.JobStepExecutions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum JobTargetTypeConstant
{
    [Description("SqlDatabase")]
    SqlDatabase,

    [Description("SqlElasticPool")]
    SqlElasticPool,

    [Description("SqlServer")]
    SqlServer,

    [Description("SqlShardMap")]
    SqlShardMap,

    [Description("TargetGroup")]
    TargetGroup,
}
