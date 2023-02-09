using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.StorageCache.v2021_09_01.Caches;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum HealthStateTypeConstant
{
    [Description("Degraded")]
    Degraded,

    [Description("Down")]
    Down,

    [Description("Flushing")]
    Flushing,

    [Description("Healthy")]
    Healthy,

    [Description("Stopped")]
    Stopped,

    [Description("Stopping")]
    Stopping,

    [Description("Transitioning")]
    Transitioning,

    [Description("Unknown")]
    Unknown,

    [Description("Upgrading")]
    Upgrading,
}
