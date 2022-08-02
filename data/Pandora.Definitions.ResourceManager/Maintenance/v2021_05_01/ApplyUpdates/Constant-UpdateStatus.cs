using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Maintenance.v2021_05_01.ApplyUpdates;

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
