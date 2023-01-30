using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2020_12_01.Jobs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum JobStatusConstant
{
    [Description("Canceled")]
    Canceled,

    [Description("Failed")]
    Failed,

    [Description("Invalid")]
    Invalid,

    [Description("Paused")]
    Paused,

    [Description("Running")]
    Running,

    [Description("Scheduled")]
    Scheduled,

    [Description("Succeeded")]
    Succeeded,
}
