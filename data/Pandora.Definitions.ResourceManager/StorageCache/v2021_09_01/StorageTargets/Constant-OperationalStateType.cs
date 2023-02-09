using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.StorageCache.v2021_09_01.StorageTargets;

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
