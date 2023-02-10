using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.StorageCache.v2023_01_01.StorageTargets;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OperationalStateTypeConstant
{
    [Description("Busy")]
    Busy,

    [Description("Flushing")]
    Flushing,

    [Description("Ready")]
    Ready,

    [Description("Suspended")]
    Suspended,
}
