using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.StorageCache.v2023_05_01.AmlFilesystems;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AmlFilesystemHealthStateTypeConstant
{
    [Description("Available")]
    Available,

    [Description("Degraded")]
    Degraded,

    [Description("Maintenance")]
    Maintenance,

    [Description("Transitioning")]
    Transitioning,

    [Description("Unavailable")]
    Unavailable,
}
