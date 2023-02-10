using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.StorageCache.v2023_01_01.Caches;

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

    [Description("StartFailed")]
    StartFailed,

    [Description("Stopped")]
    Stopped,

    [Description("Stopping")]
    Stopping,

    [Description("Transitioning")]
    Transitioning,

    [Description("Unknown")]
    Unknown,

    [Description("UpgradeFailed")]
    UpgradeFailed,

    [Description("Upgrading")]
    Upgrading,

    [Description("WaitingForKey")]
    WaitingForKey,
}
