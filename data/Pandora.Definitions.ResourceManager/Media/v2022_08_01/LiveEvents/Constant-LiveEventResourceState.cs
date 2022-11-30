using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Media.v2022_08_01.LiveEvents;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LiveEventResourceStateConstant
{
    [Description("Allocating")]
    Allocating,

    [Description("Deleting")]
    Deleting,

    [Description("Running")]
    Running,

    [Description("StandBy")]
    StandBy,

    [Description("Starting")]
    Starting,

    [Description("Stopped")]
    Stopped,

    [Description("Stopping")]
    Stopping,
}
