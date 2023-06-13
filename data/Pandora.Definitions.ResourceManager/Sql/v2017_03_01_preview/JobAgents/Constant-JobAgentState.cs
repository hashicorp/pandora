using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2017_03_01_preview.JobAgents;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum JobAgentStateConstant
{
    [Description("Creating")]
    Creating,

    [Description("Deleting")]
    Deleting,

    [Description("Disabled")]
    Disabled,

    [Description("Ready")]
    Ready,

    [Description("Updating")]
    Updating,
}
