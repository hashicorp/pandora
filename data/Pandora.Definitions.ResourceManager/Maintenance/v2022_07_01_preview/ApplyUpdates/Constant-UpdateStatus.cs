using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Maintenance.v2022_07_01_preview.ApplyUpdates;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum UpdateStatusConstant
{
    [Description("Completed")]
    Completed,

    [Description("InProgress")]
    InProgress,

    [Description("Pending")]
    Pending,

    [Description("RetryLater")]
    RetryLater,

    [Description("RetryNow")]
    RetryNow,
}
