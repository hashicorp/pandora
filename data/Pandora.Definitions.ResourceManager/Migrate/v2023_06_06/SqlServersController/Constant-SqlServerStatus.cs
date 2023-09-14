using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.SqlServersController;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SqlServerStatusConstant
{
    [Description("ContinuePending")]
    ContinuePending,

    [Description("PausePending")]
    PausePending,

    [Description("Paused")]
    Paused,

    [Description("Running")]
    Running,

    [Description("StartPending")]
    StartPending,

    [Description("StopPending")]
    StopPending,

    [Description("Stopped")]
    Stopped,

    [Description("Unknown")]
    Unknown,
}
